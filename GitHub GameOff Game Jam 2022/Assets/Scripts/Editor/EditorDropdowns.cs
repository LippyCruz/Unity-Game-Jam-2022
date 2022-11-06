using TimeManagement;
using UIManagement;
using UnityEditor;
using UnityEngine;

public class EditorDropdowns : EditorWindow
{
    // Logging

    [MenuItem("Gamejam/Logging/LogCurrentTimeAndPhase", false, 0)]
    static void LogCurrentTimeAndPhase()
    {
        IgnoreIdleEditorActions();
        Debug.Log($"Time: {TimeManager.Instance.CurrentTime} and Phase: {TimeManager.Instance.CurrentPhase}");
    }

    // Time

    [MenuItem("Gamejam/Time/ForceNextPhase", false, 0)]
    static void ForceNextPhase()
    {
        IgnoreIdleEditorActions();
        TimeManager.Instance.FinishCurrentPhase();
    }

    // UI

    [MenuItem("Gamejam/UI/Enqueue All Test Notifications")]
    static void EnqueueAllTestNotification()
    {
        IgnoreIdleEditorActions();
        UIPanelQueue.Instance.EnqueueMoneyReception(5);
        UIPanelQueue.Instance.EnqueueBuildingReception(BuildingManagement.BuildingType.ACRE);
        UIPanelQueue.Instance.EnqueueCardReception(new UIPanelQueue.Card());
        UIPanelQueue.Instance.EnqueueMoneyReception(12);
    }

    [MenuItem("Gamejam/UI/Enqueue Test Money Notification")]
    static void EnqueueTestMoneyNotification()
    {
        IgnoreIdleEditorActions();
        UIPanelQueue.Instance.EnqueueMoneyReception(5);
    }

    [MenuItem("Gamejam/UI/Enqueue Test Building Notification")]
    static void EnqueueTestBuildingNotification()
    {
        IgnoreIdleEditorActions();
        UIPanelQueue.Instance.EnqueueBuildingReception(BuildingManagement.BuildingType.ACRE);
    }

    [MenuItem("Gamejam/UI/Enqueue Test Card Notification")]
    static void EnqueueTestCardNotification()
    {
        IgnoreIdleEditorActions();
        UIPanelQueue.Instance.EnqueueCardReception(new UIPanelQueue.Card()); // TODO: Replace by actual card class
    }

    // Management

    private static void IgnoreIdleEditorActions()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
    }
}
