using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuildingCard", menuName = "Cards/SeedCard")]
public class SeedCard : ActionCardSO
{
    public override void Action()
    {
        Debug.Log("Played card!");
    }
}
