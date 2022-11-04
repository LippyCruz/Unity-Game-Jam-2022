namespace UIManagement
{
    using BuildingManagement;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    /// <summary>
    /// The UIPanelQueue class is used to enqueue UI panels like notifications or confirmation
    /// panels, which will be displayed at the beginning of the turn. After all panels have
    /// been displayed, the player's actions are unlocked and can be used.
    /// </summary>
    public class UIPanelQueue : MonoBehaviour
    {
        [Header("UI Notification Panel")]
        // The base GameObject of the notification panel
        [SerializeField] private GameObject notificationPanel;

        // The background panel image of the notification panel
        [SerializeField] private Image notificationPanelImage;

        // The animator of the notification panel used for triggering the animations
        [SerializeField] private Animator notificationPanelAnimator;



        [Header("UI Confirmation Panel")]
        // The base GameObject of the confirmation panel
        [SerializeField] private GameObject confirmationPanel;

        // The base GameObject of the confirmation panel
        [SerializeField] private TMP_Text confirmationTitleText;



        // In the beginning of each turn, all panels will be dequeued and displayed
        private Queue<UIPanel> uiPanelQueue;

        // TODO: Use the correct class from Crostzard
        public class Card { }

        // TODO: Use the correct event from Ben
        [HideInInspector] public UnityEvent onNewTurn;

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
        private class ItemReceptionUIPanel : UIPanel
        {
            public Card ReceivedCard { get; set; }
        }

        /// <summary>
        /// On game start, setup the queue class
        /// </summary>
        private void Awake()
        {
            uiPanelQueue = new Queue<UIPanel>();
            onNewTurn.AddListener(() => InitiateQueue());

            // TEST, TODO: Remove
            AddMoneyReception(5);
            AddBuildingReception(BuildingType.ACRE);
            AddItemReception(new Card());
            AddMoneyReception(3);
            onNewTurn.Invoke();
        }

        /// <summary>
        /// Enqueues a panel to the UIPanelQueue displaying that the player has
        /// received a certain amount of money
        /// </summary>
        /// <param name="amountToDisplay">The amount of money received by the player</param>
        public void AddMoneyReception(int amountToDisplay)
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
        public void AddBuildingReception(BuildingType buildingToDisplay)
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
        public void AddItemReception(Card cardToDisplay)
        {
            var panel = new ItemReceptionUIPanel()
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
        private void DisplayNotification(Color panelColour)
        {
            notificationPanel.SetActive(true);
            notificationPanelImage.color = panelColour;
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
                // (!) TEST. TODO: Replace by animation
                print($"[TEST]: Received {moneyPanel.ReceivedMoneyAmount}$!");
                DisplayNotification(Color.yellow);
            }
            else if (currentPanel is BuildingReceptionUIPanel buildingPanel)
            {
                // (!) TEST. TODO: Replace by animation
                print($"[TEST]: Received {buildingPanel.ReceivedBuildingType.ToString()}!");
                DisplayNotification(Color.red);
            }
            else if (currentPanel is ItemReceptionUIPanel itemPanel)
            {
                // (!) TEST. TODO: Replace by animation
                print($"[TEST]: Received Card: {itemPanel.ReceivedCard}!");
                DisplayCardConfirmation("New Card Received:", itemPanel.ReceivedCard);
            }
            else throw new System.NotImplementedException($"The UI panel '{currentPanel}' is not implemented");
        }

        /// <summary>
        /// Determines whether there are still UI panels in the queue (true) 
        /// or if the queue is empty (false)
        /// </summary>
        /// <returns>true: The queue is not empty, false: The queue is empty</returns>
        private bool UIPanelsAreEnqueued() => uiPanelQueue.Count != 0;
    }
}
