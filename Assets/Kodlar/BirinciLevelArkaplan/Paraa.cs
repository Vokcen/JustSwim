using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paraa : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.collider.tag;
        if (tag.Equals("Coin"))
        {

            Destroy(other.gameObject);
        }
        if (tag.Equals("Düsman"))   
        {
            Destroy(other.gameObject);
        }
    }
   }
