using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "Inventory/Resource")]
public class ResourceSO : ScriptableObject
{
    public int sellPrice; //sell value for trade

    public string resourceName; //this is the string that will be compared for game logic, should be entirely lower case (ex. "wheat")
    public string displayName; //this is the name that should be displayed to the player, starting with an upper case letter (ex. "Wheat")

    public Sprite resourceSprite;
}
