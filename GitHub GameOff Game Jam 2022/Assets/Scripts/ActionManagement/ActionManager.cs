namespace ActionManagement
{
    using System;
    using UnityEngine;

    /// <summary>
    /// This class is used to manage the player's actions and provides utility functions
    /// to lock/unlock, strengthen/weaken actions
    /// </summary>
    public class ActionManager : MonoBehaviour
    {
        // The ActionManager's singleton
        private static ActionManager _instance = null;
        public static ActionManager Instance {
            get {
                if (_instance == null)
                    throw new Exception("ActionManager singleton was called without ActionManager being set up (check that ActionManager is in the scene)");
                return _instance;
            }
            private set { _instance = value; }
        }

        // The constants define how strong the actions can be (at the moment: in range(1,3) incl. incl.)
        public const int MIN_STRENGTH = 1, MAX_STRENGTH = 3;

        // There are three strengths: 3 = strong, 2 = medium, 1 = weak. (!) 0 does not exist
        private int[] actionStrengths;

        // Determines whether the player can currently use the action system generally or not
        private bool systemIsLocked;

        // Determines whether the player has already used one action this round or not
        private bool actionWasConsumed;

        private void Awake() {
            // Sets up the singleton
            if (_instance == null) Instance = this;
            else throw new System.InvalidProgramException("Trying to instantiate the " +
                "ActionManager singleton, but it already exists. Is there another script in the scene?");

            ReplenishAllActions(); // assumes we reload the scene every time we start a game
        }

        /// <summary>
        /// Used for temporarily disabling action taking, for example when
        /// important UI interactions are required
        /// </summary>
        public void LockSystem() => systemIsLocked = true;

        /// <summary>
        /// Unlocks the system, making the player able do an action, if 
        /// an action has not been used in the turn, yet
        /// </summary>
        public void UnlockSystem() => systemIsLocked = false;

        /// <summary>
        /// Sets the strengths of all actions to the maximum value (3)
        /// </summary>
        public void ReplenishAllActions() 
        {
            actionStrengths = new int[5];
            for (int i = 0; i < actionStrengths.Length; i++)
            {
                actionStrengths[i] = MAX_STRENGTH;
            }
        }

        /// <summary>
        /// Strengthens the selected action by one point
        /// </summary>
        /// <param name="actionToStrengthen">The action type, which should be strengthened</param>
        public void StrengthenAction(ActionType actionToStrengthen)
        {
            int actionIndex = ConvertActionTypeToIndex(actionToStrengthen);

            // The Weaken function only weakens actions that can stil be strengthened 
            if (actionStrengths[actionIndex] < MAX_STRENGTH)
            {
                actionStrengths[actionIndex]++;
            }
        }

        /// <summary>
        /// Weakens the selected action by one point
        /// </summary>
        /// <param name="actionToWeaken">The action type, which should be weakened</param>
        public void WeakenAction(ActionType actionToWeaken)
        {
            int actionIndex = ConvertActionTypeToIndex(actionToWeaken);

            // The Weaken function only weakens actions that can stil be weakened 
            if (actionStrengths[actionIndex] > MIN_STRENGTH)
            {
                actionStrengths[actionIndex]--;
            }
        }

        /// <summary>
        /// Retrieves the strength of the selected action type [1: weak, 2: medium, 3: strong]
        /// </summary>
        /// <param name="ofAction">The action type, the strength of which is requested</param>
        /// <returns>The strength of the action in range (1,3) incl. incl.</returns>
        public int GetStrengthOfAction(ActionType ofAction) => actionStrengths[ConvertActionTypeToIndex(ofAction)];

        /// <summary>
        /// Retrieves all action strengths to be used for a quick access of all strengths
        /// </summary>
        /// <returns>An array with all action strengths</returns>
        public int[] GetAllStrengths() => actionStrengths;

        /// <summary>
        /// Turns an ActionType constant into its numerical index representation
        /// </summary>
        /// <param name="actionType">The action type to be converted</param>
        /// <returns>The unique index of the action type</returns>
        /// <see cref="ActionType"/>
        /// <exception cref="System.NotImplementedException">
        /// Thrown when trying to convert an unimplemented action type
        /// </exception>
        private int ConvertActionTypeToIndex(ActionType actionType) 
        {
            return actionType switch
            {
                ActionType.DRAW => 0,
                ActionType.SUPPORT => 1,
                ActionType.CULTIVATE => 2,
                ActionType.BUILD => 3,
                ActionType.REST => 4,
                _ => throw new System.NotImplementedException($"The ActionType '{actionType}' is not " +
                $"implemented and does not have a corresponding index yet")
            };
        }
    }
}
