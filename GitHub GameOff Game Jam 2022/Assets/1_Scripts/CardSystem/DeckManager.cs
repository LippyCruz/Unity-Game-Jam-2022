using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{

    public ActionCardSO[] availableCards;

    public RectTransform deckUIBounds; // So, the player in order to play a card has to click somewhere on the screen, except inside this transform.

    public int CardsOnDeck { get { return transform.childCount; } }

    CardScript selected;

    public CardScript Selected { get { return selected; } set { selected = value; } }

    float playCooldown = 0.3f;
    float timer;
    

    void Update()
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


}
