using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardScript : MonoBehaviour, IPointerDownHandler
{

    ActionCardSO card;

    public ActionCardSO Card { get { return card; } set { card = value; } }

    Image image;


    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    void Start()
    {
        image = GetComponent<Image>();

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


}
