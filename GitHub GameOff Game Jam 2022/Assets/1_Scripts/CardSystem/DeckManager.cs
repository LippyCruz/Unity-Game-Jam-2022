using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // CROSTZARD

    //Summary: Handles all things related to your OWN deck.
    //E.g: Playing cards or selecting cards.


    // Card events
    public delegate void CardEvents();
    public event CardEvents OnCardLeave;

    public DeckTableManager deckTable;

    // So, the player in order to play a card has to click somewhere on the screen, except inside this transform.
    public RectTransform deckUIBounds;

    // Where do cards start appearing from? I'll position cards according to this position.
    public Transform deckStartPoint;

    // Amount of cards in my hand
    public int CardsOnDeck { get { return currentCards.Count; } }

    // Selected card
    CardScript selected;
    public CardScript Selected { get { return selected; } set { selected = value; } }

    // Current cards on my hand. I use this for positioning cards
    [HideInInspector]
    private List<CardScript> currentCards = new List<CardScript>();

    float playCooldown = 0.3f;
    float timer;


    private void Start()
    {
        EventSubscription();
    }

    void Update()
    {

        PlayCard();
    }

    private void PlayCard()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {

            if (timer < playCooldown) return;
            if (deckUIBounds == null) return;
            if (selected == null) return;

            Vector3 pos = Input.mousePosition;
            pos.z = 0;

            if (!RectTransformUtility.RectangleContainsScreenPoint(deckUIBounds, pos))
            {
                selected.Card.Action();
                OnCardLeave.Invoke();
            }
            else DeselectCard();


        }
    }

    public void SelectCard(CardScript card) 
    {
        timer = 0;
        DeselectCard();

        if (card.Animator == null) return;

        selected = card;
        card.Animator.Play("Card_Selected");
    }   

    public void DeselectCard() 
    {
        if (selected != null)
        {
            selected.Animator.Play("Card_Deselected");
            selected = null;
        }
    }

    public void DiscardCard(CardScript card) 
    {
        card.gameObject.SetActive(false);
        currentCards.Remove(card);
        deckTable.pooledCards.Add(card.gameObject);

        OnCardLeave.Invoke();
    }


    private void CardPositioning() 
    { 
        for (int i = 0; i < currentCards.Count; i++) 
        {

            Vector3 startPos = deckStartPoint.localPosition;

            float Xpos = startPos.x + (i * 60);

            Vector3 pos = startPos;
            pos.x = Xpos;

            currentCards[i].transform.localPosition = pos;


        }
        
    }


    public void AddCardToList(CardScript card) 
    {
        currentCards.Add(card);
        CardPositioning();
    }


    private void EventSubscription() 
    {
        OnCardLeave += CardPositioning;
    }



}
