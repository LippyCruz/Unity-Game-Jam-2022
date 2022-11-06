namespace UIManagement
{
    using UnityEngine;

    /// <summary>
    /// This class is used to equip animated UI elements with the ability to initiate
    /// the next panel in the UIPanelQueue as soon as their animation ends
    /// </summary>
    /// <author>Gino</author>
    public class AnimationQueueTrigger : MonoBehaviour
    {
        [SerializeField] private UIPanelQueue uiPanelQueue;

        /// <summary>
        /// This method should be called on the animation event
        /// </summary>
        public void TriggerNextElementOnAnimationEnd() => uiPanelQueue.InitiateNextPanel();
    }
}
