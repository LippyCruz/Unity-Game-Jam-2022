
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Assertions;

public class EditorDropdowns : EditorWindow
{

    [MenuItem("Gamejam/Logging/LogCurrentTimeAndPhase", false, 0)]
    static void LogCurrentTimeAndPhase() {
        if (!EditorApplication.isPlaying) {
            return;
        }
        Debug.Log($"Time: {TimeManager.Instance.CurrentTime} and Phase: {TimeManager.Instance.CurrentPhase}");
    }

    [MenuItem("Gamejam/Time/ForceNextPhase", false, 0)]
    static void ForceNextPhase() {
        if (!EditorApplication.isPlaying) {
            return;
        }
        TimeManager.Instance.FinishCurrentPhase();
    }
}
