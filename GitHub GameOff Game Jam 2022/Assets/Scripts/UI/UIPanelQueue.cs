namespace UIManagement
{
    using BuildingManagement;
    using System;
    using System.Collections.Generic;
    using TimeManagement;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// The UIPanelQueue class is used to enqueue UI panels like notifications or confirmation
    /// panels, which will be displayed at the beginning of the turn. After all panels have
    /// been displayed, the player's actions are unlocked and can be used.
    /// </summary>
    /// <author>Gino</author>
    public class UIPanelQueue : MonoBehaviour
    {
        // The UIActionPanel's singleton
        private static UIPanelQueue _instance = null;
        public static UIPanelQueue Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("UIPanelQueue singleton was called without " +
                        "UIPanelQueue being set up (check that UIPanelQueue is in the scene)");
                return _instance;
            }
            private set { _instance = value; }
        }



        [Header("UI Notification Panel")]
        // The base GameObject of the notification panel
        [SerializeField] private GameObject notificationPanel;

        // The background panel image of the notification panel
        [SerializeField] private Image notificationPanelImage;

        // The icon image of the notification
        [SerializeField] private Image notificationPanelIconImage;

        // The animator of the notification panel used for triggering the animations
        [SerializeField] private Animator notificationPanelAnimator;

        // The text component of the notification panel displaying the actual notification string
        [SerializeField] private TMP_Text notificationPanelText;



        [Header("UI Confirmation Panel")]
        // The base GameObject of the confirmation panel
        [SerializeField] private GameObject confirmationPanel;

        // The text component of the confirmation panel describing what the confirmation reason is
        [SerializeField] private TMP_Text confirmationTitleText;



        [Header("UI Notification Icons")]
        [SerializeField] private Sprite moneyNotificationIcon; 
        [SerializeField] private Sprite buildingNotificationIcon; 



        // In the beginning of each turn, all panels will be dequeued and displayed
        private Queue<UIPanel> uiPanelQueue;

        // TODO: Use the correct class from Crostzard
        public class Card { }

        /// <summary>
        /// The base class of all UI panels
        /// </summary>
        private abstract class UIPanel { }

        /// <summary>
        /// A short notification displaying the received amount of money
        /// </summary>
        private class MoneyReceptionUIPanel : UIPanel
        {
            public int ReceivedMoneyAmount { get; set; }
        }

        /// <summary>
        /// A short notification displaying the received building
        /// </summary>
        private class BuildingReceptionUIPanel : UIPanel
        {
            public BuildingType ReceivedBuildingType { get; set; }
        }

        /// <summary>
        /// An entire panel displaying the received card together with a 
        /// confirmation button
        /// </summary>
        private class CardReceptionUIPanel : UIPanel
        {
            public Card ReceivedCard { get; set; }
        }

        /// <summary>
        /// On game start, setup the queue class
        /// </summary>
        private void Awake()
        {
            // Sets up the singleton
            if (_instance == null) Instance = this;
            else throw new InvalidProgramException("Trying to instantiate the " +
                "UIPanelQueue singleton, but it already exists. Is there another script in the scene?");

            uiPanelQueue = new Queue<UIPanel>();
            TimeManager.OnStartPreTurn.AddListener(InitiateQueue);
        }

        /// <summary>
        /// Enqueues a panel to the UIPanelQueue displaying that the player has
        /// received a certain amount of money
        /// </summary>
        /// <param name="amountToDisplay">The amount of money received by the player</param>
        public void EnqueueMoneyReception(int amountToDisplay)
        {
            var panel = new MoneyReceptionUIPanel()
            {
                ReceivedMoneyAmount = amountToDisplay
            };

            uiPanelQueue.Enqueue(panel);
        }

        /// <summary>
        /// Enqueues a panel to the UIPanelQueue displaying that the player has
        /// received a new building that they can place in their farm
        /// </summary>
        /// <param name="buildingToDisplay">The building (acre, warehouse, etc.) received by the player</param>
        public void EnqueueBuildingReception(BuildingType buildingToDisplay)
        {
            var panel = new BuildingReceptionUIPanel()
            {
                ReceivedBuildingType = buildingToDisplay
            };

            uiPanelQueue.Enqueue(panel);
        }

        /// <summary>
        /// Enqueues a panel to the UIPanelQueue displaying that the player has
        /// received a new card that is added to their handcards
        /// (!) This needs to be confirmed by the player
        /// </summary>
        /// <param name="cardToDisplay">The card that should be displayed</param>
        public void EnqueueCardReception(Card cardToDisplay)
        {
            var panel = new CardReceptionUIPanel()
            {
                ReceivedCard = cardToDisplay
            };

            uiPanelQueue.Enqueue(panel);
        }

        /// <summary>
        /// In the beginning of each round, all messages of the queue are displayed
        /// one after the other. After the final message was displayed, unlocks the 
        /// player's actions.
        /// </summary>
        private void InitiateQueue()
        {
            // LockActions(); TODO: Implement
            print("[LOCK PLAYER ACTIONS]");

            InitiateNextPanel();
        }

        /// <summary>
        /// When all queue elements have been displayed, unlock the player's actions
        /// </summary>
        private void EndQueueDisplay()
        {
            // UnlockActions(); TODO: Implement
            print("[UNLOCK PLAYER ACTIONS]");
            TimeManager.Instance.FinishCurrentPhase();
        }

        /// <summary>
        /// Displays the next panel if the queue is not empty, and ends the display if it is.
        /// (!) This method should only be called from animation events and confirmation buttons
        /// </summary>
        public void InitiateNextPanel()
        {
            DeactivateAllPanels();

            if (UIPanelsAreEnqueued())
            {
                DisplayCurrentPanel();
            }
            else
            {
                EndQueueDisplay();
            }
        }

        /// <summary>
        /// Deactivates the GameObjects of the notification and confirmation panels
        /// </summary>
        private void DeactivateAllPanels()
        {
            notificationPanel.SetActive(false);
            confirmationPanel.SetActive(false);
        }

        /// <summary>
        /// Activates the panel GameObject, sets its panel colour and plays the animation
        /// </summary>
        /// <param name="panelColour">The background colour of the notification panel</param>
        private void DisplayNotification(Color panelColour, Sprite notificationIcon)
        {
            notificationPanel.SetActive(true);
            notificationPanelImage.color = panelColour;
            notificationPanelIconImage.sprite = notificationIcon;
            notificationPanelAnimator.Play("UINotificationPanelDisplay");
        }

        /// <summary>
        /// Displays a panel showing a title, a card, and a confirmation button. This can be
        /// used for scenarios like 'You have received this card' or 'An earthquake destroyed
        /// this card', etc. Note that this only for confirming choices, not rejecting them
        /// </summary>
        /// <param name="confirmationTitle">What text should be displayed</param>
        /// <param name="cardToDisplay">What card should be displayed</param>
        private void DisplayCardConfirmation(string confirmationTitle, Card cardToDisplay)
        {
            // TODO: Set the card image

            confirmationPanel.SetActive(true);
            confirmationTitleText.text = confirmationTitle;
        }

        /// <summary>
        /// Depending on the current panel type, sets the UI text, icons and plays 
        /// the respective animation
        /// </summary>
        private void DisplayCurrentPanel()
        {
            var currentPanel = uiPanelQueue.Dequeue();

            if (currentPanel is MoneyReceptionUIPanel moneyPanel)
            {
                notificationPanelText.text = $"Received {moneyPanel.ReceivedMoneyAmount}$!";
                DisplayNotification(Color.yellow, moneyNotificationIcon);
            }
            else if (currentPanel is BuildingReceptionUIPanel buildingPanel)
            {
                notificationPanelText.text = $"Received {buildingPanel.ReceivedBuildingType}!";
                DisplayNotification(Color.red, buildingNotificationIcon);
            }
            else if (currentPanel is CardReceptionUIPanel cardPanel)
            {
                notificationPanelText.text = $"Received Card: {cardPanel.ReceivedCard}!";
                DisplayCardConfirmation("New Card Received:", cardPanel.ReceivedCard);
            }
            else throw new NotImplementedException($"The UI panel '{currentPanel}' is not yet implemented!");
        }

        /// <summary>
        /// Determines whether there are still UI panels in the queue (true) 
        /// or if the queue is empty (false)
        /// </summary>
        /// <returns>true: The queue is not empty, false: The queue is empty</returns>
        private bool UIPanelsAreEnqueued() => uiPanelQueue.Count != 0;
    }
}
