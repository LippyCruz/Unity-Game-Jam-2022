using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MapManager : EditorWindow
{
    [SerializeField]
    TileTypeSO plain;
    TileTypeSO mountains;
    TileTypeSO sea;
    TileTypeSO forest;


    public static void ShowWindow()
    {
        GetWindow<MapManager>("Map Manager");
    }

    public void OnGUI()
    {
        plain = (TileTypeSO)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Grid/TileTypes/Plains.asset", typeof(TileTypeSO));
        mountains = (TileTypeSO)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Grid/TileTypes/Mountains.asset", typeof(TileTypeSO));
        sea = (TileTypeSO)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Grid/TileTypes/Sea.asset", typeof(TileTypeSO));
        forest = (TileTypeSO)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Grid/TileTypes/Forest.asset", typeof(TileTypeSO));

        GUILayout.Label("Tile Selection", EditorStyles.label);
        GUILayout.BeginVertical();
        EditorGUILayout.LabelField("Tile Type", GUILayout.MaxWidth(125));
        if (GUILayout.Button("Forest"))
        {
            foreach (GameObject i in Selection.gameObjects)
            {
                if (forest == null)
                {
                    Debug.LogError("Forest tile asset null");
                }
                Debug.Log("clicked");
                i.gameObject.GetComponent<Tile>().updateAppearance(forest);
            }
        }
        if (GUILayout.Button("Sea"))
        {
            foreach (GameObject i in Selection.gameObjects)
            {
                if (sea == null)
                {
                    Debug.LogError("Sea tile asset null");
                }
                i.gameObject.GetComponent<Tile>().updateAppearance(sea);
            }
        }
        if (GUILayout.Button("Mountains"))
        {
            foreach (GameObject i in Selection.gameObjects)
            {
                if (mountains == null)
                {
                    Debug.LogError("Mountain tile asset null");
                }
                i.gameObject.GetComponent<Tile>().updateAppearance(mountains);
            }
        }
        if (GUILayout.Button("Plains"))
        {
            foreach (GameObject i in Selection.gameObjects)
            {
                if (plain == null)
                {
                    Debug.LogError("Plain tile asset null");
                }
                i.gameObject.GetComponent<Tile>().updateAppearance(plain);
            }
        }
        GUILayout.EndVertical();
    }
}
