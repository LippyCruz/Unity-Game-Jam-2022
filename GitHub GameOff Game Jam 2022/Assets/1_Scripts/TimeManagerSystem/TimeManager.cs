using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// owns the source of truth for the current state of time, and 
/// owns publishing events which indicate the passage of time
/// </summary>
public class TimeManager : MonoBehaviour {

    public bool DebugMode;

    public PointInTime currentTime;
    public SOEvent_PointInTime OnTimeProgressedEvent;

    public void HandleInitializeGameEvent() {
        currentTime = PointInTime.GenerateFirstPointInTime();
        if (DebugMode) Debug.Log($"TimeManager received initialize game event. Setting time to {currentTime}. now will fire time progressed event");
        OnTimeProgressedEvent.Raise(currentTime);
    }

    public void HandlePlayerTurnEndEvent() {
        currentTime = currentTime.GenerateNext();
        if (DebugMode) Debug.Log($"TimeManager received player turn end event. incremented time to {currentTime}. now will fire time progressed event");
        OnTimeProgressedEvent.Raise(currentTime);
    }

}

