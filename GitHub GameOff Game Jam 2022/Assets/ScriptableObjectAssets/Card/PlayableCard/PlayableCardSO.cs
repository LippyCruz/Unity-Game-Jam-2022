using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCardSO : ScriptableObject
{
    public int deckTotal; //the total number of this card in the deck
    public int cost; //the cost in currency to play this card

    public string playableCardType; //this is the type of playable card used in game logic, such as "building" for building cards
    public string displayTitle; //the title of the card
    public string displayText; //description text for the player

    public Sprite cardSprite;
}
