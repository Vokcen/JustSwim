using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ChacterShopDatabase",menuName ="Shopping/Chacters shop database")]
public class ChacterShopDataBase : ScriptableObject
{
    public Chacter[] chacters;
    public int ChacterCounts
    {
        get { return chacters.Length; }
    }

    public Chacter GetChacter(int index)
    {
        return chacters[index];
    }
    public void PurchaseChacter(int index)
    {
        chacters[index].isPurchased = true;
    }

    void Update()
    {
        
    }
}
