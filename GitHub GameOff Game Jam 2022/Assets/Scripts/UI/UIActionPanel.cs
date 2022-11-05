namespace ActionManagement
{
    using UnityEngine;

    /// <summary>
    /// Used to manage the display of the action panel elements
    /// </summary>
    public class UIActionPanel : MonoBehaviour
    {
        // The action buttons need to be set in the inspector
        [SerializeField] private ActionButton[] actionButtons;

        private void Awake() {
            TimeManager.OnInitGame.AddListener(HandleOnInitGame);
        }

        public void HandleOnInitGame() {
            DisplayActionButtonStrengths();
        }

        public void UseAction(int actionIndex)
        {
            print($"Using Action: {actionIndex}");
        }

        /// <summary>
        /// Iterates over all action buttons and visualises the current strength
        /// </summary>
        private void DisplayActionButtonStrengths()
        {
            int[] currentStrengths = ActionManager.Instance.GetAllStrengths();

            for (int i = 0; i < actionButtons.Length; i++)
            {
                var actionButton = actionButtons[i];
                int strength = currentStrengths[i];

                actionButton.SetDisplayStrength(strength);
            }
        }
    }
}
