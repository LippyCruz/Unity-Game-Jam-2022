using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RerollButton : MonoBehaviour, IPointerDownHandler
{

    DeckManager deck;
    CardScript parentCard;


    void Start()
    {
        if (transform.parent == null) Debug.LogError("reroll button needs to be a child of the associating card");
        
        parentCard = transform.parent.GetComponent<CardScript>();
        deck = parentCard.transform.parent.GetComponent<DeckManager>();

    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicked!");
        int randInt = Random.Range(0, deck.availableCards.Length);

        parentCard.SetUpCard(deck.availableCards[randInt]);
    }
}
