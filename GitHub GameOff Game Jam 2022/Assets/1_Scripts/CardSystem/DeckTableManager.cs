using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckTableManager : MonoBehaviour, IPointerDownHandler
{

    // CROSTZARD

    //Summary: Handles all things related to the deck you draw cards from (as Im writing this its just a button).
    // E.g : Giving cards at the start of the match, or when the player draws from the deck.

    public ActionCardSO[] availableCards;

    public DeckManager manager;
    public GameObject cardPrefab;

    float cooldown = 0.2f;
    float timer;

    [HideInInspector]
    public List<GameObject> pooledCards = new List<GameObject>();

    public void Start()
    {

        GiveCard(5); // When the game starts, give the player 5 cards.
    }

    public void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (timer < cooldown) return;
        if (manager.CardsOnDeck >= 5) return;

        GiveCard();

        timer = 0;
    }

    /// <summary>
    /// Gives the player an amount of cards.
    /// </summary>
    /// <param name="amount"> amount given </param>

    public void GiveCard(int amount = 1) 
    {
        
        for (int i = 0; i < amount; i++)
        { 

            GameObject card = pooledCards.Count > 0 ? GetPooledCard() : Instantiate(cardPrefab, manager.transform);

            AssignCardData(card.transform);

            manager.AddCardToList(card.transform.GetComponent<CardScript>());

        }
    }

    private void AssignCardData(Transform card) 
    {
        CardScript cardScript = card.GetComponent<CardScript>();
        if (cardScript == null) return;

        int randInt = Random.Range(0, availableCards.Length);

        cardScript.Card = availableCards[randInt];
    }

    private GameObject GetPooledCard() 
    {

        GameObject card = pooledCards[0];
        pooledCards.RemoveAt(0);

        card.SetActive(true);


        return card;
    
    }

}
