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

        // TODO: Use the OnGameStart event
        void Start()
        {
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
            int[] currentStrengths = ActionManager.instance.GetAllStrengths();

            for (int i = 0; i < actionButtons.Length; i++)
            {
                var actionButton = actionButtons[i];
                int strength = currentStrengths[i];

                actionButton.SetDisplayStrength(strength);
            }
        }
    }
}
