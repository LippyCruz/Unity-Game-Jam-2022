namespace ActionManagement
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Action buttons represent the UI elements that the player interacts with
    /// in order to execute a certain action. It always displays its current
    /// strength in the form of one of three images
    /// </summary>
    public class ActionButton : MonoBehaviour
    {
        [SerializeField] private Image[] strengthDisplayImages;

        /// <summary>
        /// A warning reminding the developers that the strength display images 
        /// need to match the maximum amount defined in the ActionManager. 
        /// This helper should be removed for builds (!)
        /// </summary>
        /// <see cref="ActionManager"/>
        private void Start()
        {
            if (strengthDisplayImages.Length != ActionManager.MAX_STRENGTH)
                throw new System.MissingMemberException("[HELPER] Trying to start the game, but there" +
                    "is at least one action button with an illegal amount of strength display images. " +
                    "To resolve this issue, make sure every action button has references to the " +
                    "same amount of strength images as the maximum strength defined in the ActionManager!");
        }

        /// <summary>
        /// Hides all strength images and then displays the image at the specified index
        /// </summary>
        /// <param name="strengthIndex">
        /// The strength image to be displayed (1: weak, 2: medium, 3: strong) 
        /// </param>
        /// <exception cref="System.IndexOutOfRangeException">Thrown if the index is not in range</exception>
        public void SetDisplayStrength(int strengthIndex)
        {
            int index = strengthIndex - 1;

            if (index < 0 || index >= strengthDisplayImages.Length)
                throw new System.IndexOutOfRangeException($"Strength index '{index}' " +
                    $"cannot be negative or bigger than the ActionPanel's amount of strength display images");

            HideAllStrengthImages();
            strengthDisplayImages[index].enabled = true;
        }

        /// <summary>
        /// Deactivates the Image component of all strength display images
        /// </summary>
        private void HideAllStrengthImages()
        {
            foreach (Image image in strengthDisplayImages)
            {
                image.enabled = false;
            }
        }
    }
}
