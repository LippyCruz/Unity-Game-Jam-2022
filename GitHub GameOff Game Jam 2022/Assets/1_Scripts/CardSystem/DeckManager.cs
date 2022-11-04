using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{

    public ActionCardSO[] availableCards;

    public int CardsOnDeck { get { return transform.childCount; } }

    void Awake()
    {
        

    }

    void Update()
    {
        
    }
}
