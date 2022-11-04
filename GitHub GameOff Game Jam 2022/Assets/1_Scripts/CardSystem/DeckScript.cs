using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckScript : MonoBehaviour, IPointerDownHandler
{

    public DeckManager manager;
    public GameObject cardPrefab;
    public Transform deckStartPoint;

    float cooldown = 0.2f;
    float timer;

    [SerializeField]
    private int cardPool = 30; // Max cards that can be drawn
    [SerializeField]
    private int cardsPerCol = 12;
    [SerializeField]
    private int cardsPerRow = 3;

    int cardsLeft;

    public void Start()
    {
        cardsLeft = cardPool;

        GiveCard(3);

    }

    public void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (timer < cooldown) return;
        if (cardsLeft <= 0) 
        {
            Debug.Log("Deck is empty, can't keep drawing cards");
            return;
        }

        GiveCard();

        timer = 0;
    }

    public void GiveCard(int amount = 1) 
    {
        
        for (int i = 0; i < amount; i++)
        { 
            if (manager.CardsOnDeck >= cardsPerCol * cardsPerRow) return;

            GameObject card = Instantiate(cardPrefab, manager.transform);

            PositionCard(card.transform, manager.CardsOnDeck - 1);

            AssignCardData(card.transform);
            cardsLeft -= 1;
        }

    }

    private void PositionCard(Transform card, int cardNumber) 
    {

        int yValue = -1 * (int)(cardNumber / cardsPerRow) * 60;
        int xValue = 60 * (int)(cardNumber % cardsPerRow);
        
        Vector3 pos = deckStartPoint.GetComponent<RectTransform>().localPosition;

        RectTransform rect = card.GetComponent<RectTransform>();

        rect.anchoredPosition = new Vector3(pos.x + xValue, pos.y + yValue, 0);
    }

    private void AssignCardData(Transform card) 
    {
        CardScript cardScript = card.GetComponent<CardScript>();
        if (cardScript == null) return;

        int randInt = Random.Range(0, manager.availableCards.Length);

        cardScript.Card = manager.availableCards[randInt];
    }

}
