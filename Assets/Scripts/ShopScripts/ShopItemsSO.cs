﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="ShopMenu",menuName ="Scriptable Objects/New Shop Item",order =1)]
public class ShopItemsSO : ScriptableObject
{

    public string title;
    public string description;
    public int baseCost;
    public Image knife;
}
