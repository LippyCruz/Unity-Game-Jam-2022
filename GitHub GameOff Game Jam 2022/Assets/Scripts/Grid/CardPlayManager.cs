using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlayManager : MonoBehaviour
{
    public Stack<Tile> CurrentPlayActions = new Stack<Tile>();
    public ActionCardSO CurrentCardBeingPlayed;
    int requiredActionsRemaining;

    public void AddCurCard(ActionCardSO card){
        if(card==null) return;
        CurrentCardBeingPlayed = card;
    }
    public void AddPlay(Tile curr){
        Tile.updateAppearance(CurrentCardBeingPlayed);
    }
}
