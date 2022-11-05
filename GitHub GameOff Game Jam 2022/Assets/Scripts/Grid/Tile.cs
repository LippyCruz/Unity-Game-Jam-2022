using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Sprite[] layers;
    
    [SerializeField]
    public TileTypeSO type;
    
    private TileTypeSO prevType; // <- store tile type when the tile is changed 

    public void undoTile(){
        updateAppearance(prevType);
    }

    
    void Awake(){
        if(type != null && type.picture != null){
            GetComponent<SpriteRenderer>().sprite = type.picture;
        }
    }

    void OnMouseDown(){
        //check if there's a build card that was clicked
        //check the amount of buildings available in card
        //if its more than 0 , change the tile type 
        // decrement the buildings available # 
        // check the current tile type as well 
        if(type!= null){
             Debug.Log($"Tile type: {type.type}");
        }
       
    }

    public void updateAppearance(TileTypeSO tile){
        if(tile == null) {return;}
        type = tile;
        GetComponent<SpriteRenderer>().sprite = type.picture;
    }

}


