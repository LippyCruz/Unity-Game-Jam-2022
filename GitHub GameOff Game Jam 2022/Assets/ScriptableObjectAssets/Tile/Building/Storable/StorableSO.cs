using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStorable", menuName = "Map Feature/Storable")]
public class StorableSO : ScriptableObject
{
    public int countdownValue; //used to track the base number of turns it takes for a storable to do something, such as for a crop to finish growing

    public string storableType; //type of storable, such as wheat or cow, should be a string entirely lower case
    public string displayName; //user-facing display name, first letter should be capitalized

    public Sprite mapSprite;
}
