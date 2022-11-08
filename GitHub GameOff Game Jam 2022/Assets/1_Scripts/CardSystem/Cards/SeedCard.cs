using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuildingCard", menuName = "Cards/SeedCard")]
public class SeedCard : ActionCardSO
{
    public override void Action()
    {
        // This is a seed card so I guess in this function you could put some logic?

        // Yea, this function is executed when the player plays a card

        // Hmm actually I'm not sure you can access anything here
        
    }
}

// I added 3 types of cards, though in the future we could change them a bit
// passive cards though definitely need some adjustments though, since each of them do different things so I think
// I think each should have their own script
// Correct me if im wrong but passive cards for me mean like make crops grow faster or something