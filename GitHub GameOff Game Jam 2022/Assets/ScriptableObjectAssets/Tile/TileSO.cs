using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTile", menuName = "Map Feature/Tile")]
public class TileSO : ScriptableObject
{
    public string terrainType; //terrain type, should be a string entirely lower case
    public string displayName; //user-facing display name, first letter should be capitalized

    public Sprite mapSprite;
}
