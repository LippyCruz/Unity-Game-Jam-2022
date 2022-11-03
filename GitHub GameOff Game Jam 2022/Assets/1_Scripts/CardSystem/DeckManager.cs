using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{

    public ActionCardSO[] availableCards;


    void Awake()
    {
        foreach(Transform card in transform) 
        {
            CardScript cardScript = card.GetComponent<CardScript>();
            if (cardScript == null) continue;

            int randInt = Random.Range(0, availableCards.Length);

            cardScript.Card = availableCards[randInt];

        }

    }

    void Update()
    {
        
    }
}
