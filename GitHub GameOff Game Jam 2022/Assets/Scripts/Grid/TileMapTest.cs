using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileMapTest : MonoBehaviour, IPointerDownHandler
{
   public void OnPointerDown(PointerEventData eventData){
        // Debug.Log(eventData.position);
        Debug.Log(gameObject.name);
    }

    public void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} has been clicked.");
    }
}
