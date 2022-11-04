using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerTest_PlayerTurnCompleteButton : MonoBehaviour {

    public SOEvent_Void EventToFire;

    public void HandleClick() {
        EventToFire.Raise();
    }

}
