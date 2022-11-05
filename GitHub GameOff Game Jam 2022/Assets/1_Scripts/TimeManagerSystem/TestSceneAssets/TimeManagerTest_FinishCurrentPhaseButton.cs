using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerTest_FinishCurrentPhaseButton : MonoBehaviour {

    public void HandleClick() {
        TimeManager.Instance.FinishCurrentPhase();
    }

}
