using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[ExecuteInEditMode]
public class GridSet : MonoBehaviour // attach to a script and it will auto spawn in the editor
{
     [SerializeField]
    private int width = 2;
    [SerializeField]
    private int height = 2;
    
    [SerializeField]
    private GameObject tile;
    void OnEnable()
    {
        float spriteWidth = tile.GetComponent<SpriteRenderer>().size.x;
        float spriteHeight = tile.GetComponent<SpriteRenderer>().size.y;
        for (int i = 0; i < width; i++){
            for(int f = 0; f< height; f++){
                if(tile!= null){
                    if(i % 2 == 0 ){
                        GameObject spawned = Instantiate(tile, new Vector3(transform.position.x+(i*1.5f*spriteWidth), transform.position.y-(f*2*spriteHeight),0f), Quaternion.identity, transform);
                      
                    } else {
                        GameObject spawned = Instantiate(tile, new Vector3(transform.position.x+(i*1.5f*spriteWidth), transform.position.y+1f-(f*2*spriteHeight),0f), Quaternion.identity, transform);
                    }
                    
                }
                
            }
        }
    }

}
