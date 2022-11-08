using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlayManager : MonoBehaviour
{
    //<author> Ro <author>
    /*<summary> Keeps track of what card was clicked and what tile was clicked
        in order to perform the necessary build/plant/livestock action 
        </summary>
    */
    public BuildingCard CurrentCardBeingPlayed;
    
    //TODO: Add seperate methods for building and planting/livestock
    public void AddCurCard(BuildingCard card){
        if(card==null) return;
        CurrentCardBeingPlayed = card;
    }
    public void AddPlayToTile(Tile curr){
        if(CurrentCardBeingPlayed != null){
            curr.ApplyBuildTile(CurrentCardBeingPlayed);
            CurrentCardBeingPlayed = null;
        } else {
            return; // TODO:: can have some sort of UI message here since it means a card wasn't selected
        }
     
    }
}
