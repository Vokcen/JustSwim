using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Chacter
{
    public Sprite image;
    public string name;
    [Range(0, 100)] public float speed;
    [Range(0, 100)] public float power;
    public int price;

    public bool isPurchased;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
