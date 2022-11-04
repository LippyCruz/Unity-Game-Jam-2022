using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewActionCard", menuName = "Cards/ActionCard")]
public class ActionCardSO : ScriptableObject
{

    public Sprite cardSprite;
    public Sprite buildingSprite;

    public float price = 10;


}
