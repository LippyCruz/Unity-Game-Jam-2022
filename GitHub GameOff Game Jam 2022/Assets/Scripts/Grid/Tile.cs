using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Sprite[] layers;
    
    [SerializeField]
    public TileTypeSO type;

    
    void Awake(){
        if(type != null && type.picture != null){
            GetComponent<SpriteRenderer>().sprite = type.picture;
        }
    }

    void OnMouseDown(){
        if(type!= null){
             Debug.Log($"Tile type: {type.type}");
        }
       
    }

    public void updateAppearance(TileTypeSO tile){
        Debug.Log("function start");
        if(tile == null) {return;}
        type = tile;
        Debug.Log("tile should have changed");
        GetComponent<SpriteRenderer>().sprite = type.picture;
    }

}


