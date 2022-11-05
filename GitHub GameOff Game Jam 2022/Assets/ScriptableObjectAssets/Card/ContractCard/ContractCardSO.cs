using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewContractCard", menuName = "Contract Card")]
public class ContractCardSO : ScriptableObject
{
    public int contractID; //the contract id for reference in gameplay (might change data type later?)

    public string displayName; //this is the name that should be displayed to the player, starting with an upper case letter
    public string displayText; //this is the condition display text that is displayed to the player in-game
}
