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
    private int cardPool = 14; // Max cards that can be drawn
    [SerializeField]
    private int cardsPerCol = 4;
    [SerializeField]
    private int cardsPerRow = 3;

    int cardsLeft;

    public void Start()
    {
        cardsLeft = cardPool;

    }

    public void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (timer < cooldown) return;
        if (manager.CardsOnDeck >= cardsPerRow * cardsPerCol) return;

        GameObject card = Instantiate(cardPrefab, manager.transform);

        PositionCard(card.transform, manager.CardsOnDeck - 1);

        AssignCardData(card.transform);

        cardsLeft -= 1;
        timer = 0;
    }



    private void AssignCardData(Transform card) 
    {
        CardScript cardScript = card.GetComponent<CardScript>();
        if (cardScript == null) return;

        int randInt = Random.Range(0, manager.availableCards.Length);

        cardScript.Card = manager.availableCards[randInt];
    }

    private void PositionCard(Transform card, int cardNumber) 
    {

        int yValue = -1 * (int)(cardNumber / cardsPerRow) * 60;
        int xValue = 60 * (int)(cardNumber % cardsPerRow);

        Vector3 pos = deckStartPoint.GetComponent<RectTransform>().localPosition;

        card.GetComponent<RectTransform>().localPosition = new Vector3(pos.x + xValue, pos.y + yValue, 0);

    }




}
