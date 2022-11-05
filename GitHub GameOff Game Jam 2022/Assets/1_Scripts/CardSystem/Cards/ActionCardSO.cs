using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class ActionCardSO : ScriptableObject
{

    public Sprite cardSprite;
    public Sprite buildingSprite;

    public float price = 10;

    public abstract void Action();
}
