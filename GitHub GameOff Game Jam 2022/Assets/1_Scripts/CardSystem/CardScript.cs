using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardScript : MonoBehaviour, IPointerDownHandler
{

    ActionCardSO card;
    DeckManager deckManager;

    Animator animator;
    Image image;

    public ActionCardSO Card { get { return card; } set { card = value; } }
    public Animator Animator { get { return animator; } }


    public void OnPointerDown(PointerEventData eventData)
    {
        if(deckManager.Selected == this) 
        {
            deckManager.DeselectCard();
            return;
        }

        deckManager.SelectCard(this);

    }

    void Start()
    {
        image = GetComponentInChildren<Image>();
        deckManager = transform.parent.GetComponent<DeckManager>();
        animator = GetComponentInChildren<Animator>();

        SetUpCard(card);
    }

    void Update()
    {
    }

    public void SetUpCard(ActionCardSO newCard) 
    {
        if (image == null)
        {
            Debug.LogError("Card needs an Image component");
            return;
        }

        card = newCard;

        if (card == null) return;

        image.color = Color.white;
        image.sprite = card.cardSprite;

    }

    public void DeselectCard() 
    { 
        
    }


}
