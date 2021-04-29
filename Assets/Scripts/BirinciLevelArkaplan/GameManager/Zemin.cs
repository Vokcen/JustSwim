using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zemin : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.collider.tag;
        if (tag.Equals("Coin"))
        {
           

            Destroy(other.gameObject);
        }

    }
  
}
