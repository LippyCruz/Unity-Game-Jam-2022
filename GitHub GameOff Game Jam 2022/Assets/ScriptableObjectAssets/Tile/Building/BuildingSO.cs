using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "Map Feature/Building")]
public class BuildingSO : ScriptableObject
{
    public int countdownValue; //used to track the base number of turns it takes for a building to do something (could be used at some point)

    public string buildingType; //type of building, should be a string entirely lower case
    public string displayName; //user-facing display name, first letter should be capitalized

    public Sprite mapSprite;
}
