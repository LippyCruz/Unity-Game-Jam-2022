using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingManagement;

[CreateAssetMenu(fileName = "NewBuildingCard", menuName = "Cards/SeedCard")]
public class SeedCard : ActionCardSO
{
    private CardPlayManager cardPlayManager;
    public SeedType buildingType;
    public override void Action()
    {
        cardPlayManager = FindObjectOfType<CardPlayManager>();
        if(cardPlayManager == null){
            Debug.LogError("CardPlayManager script missing!");
            return;
        }
        cardPlayManager.AddCurCard(this);
        // build action here
    }
}

// I added 3 types of cards, though in the future we could change them a bit
// passive cards though definitely need some adjustments though, since each of them do different things so I think
// I think each should have their own script
// Correct me if im wrong but passive cards for me mean like make crops grow faster or something