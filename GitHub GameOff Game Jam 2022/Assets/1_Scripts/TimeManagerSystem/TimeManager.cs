using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// owns the source of truth for the current state of time, and 
/// owns publishing events which indicate the passage of time
/// </summary>
public class TimeManager : MonoBehaviour {

    public PointInTime currentTime;
    public SOEvent_PointInTime OnTimeProgressedEvent;

    public void HandleInitializeGameEvent() {
        currentTime = PointInTime.GenerateFirstPointInTime();
    }

    public void HandlePlayerTurnEndEvent() {
        currentTime = currentTime.GenerateNext();
        OnTimeProgressedEvent.Raise(currentTime);
    }

}

