using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class TimeDisplayer : MonoBehaviour {

    public TextMeshProUGUI footerText;

    private void Awake() {
        Assert.IsNotNull(footerText);
    }

    public void HandleTimeProgressedEvent(PointInTime time) {
        Debug.Log($"TimeDisplayer received TimeProgressedEvent {time}");
        UpdateUIElementsForNewTime(time);
    }

    private void UpdateUIElementsForNewTime(PointInTime time) {
        footerText.text = $"{time.SeasonInYear}.\n{time.GetRoundsRemainingInSeason()} months until {time.GetNextSeason()}";
    }
}
