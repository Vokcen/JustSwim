using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class SolKöse : MonoBehaviour
{
   
    public  float SolKösehiz = 5f;
    GameObject[]  köseler;
    float cameraY;
    float köseYükseklik;
    void Awake() 
    {
        köseler = GameObject.FindGameObjectsWithTag("SolKöseler");
        cameraY = Camera.main.transform.position.y - 15;
        köseYükseklik = GetComponent<BoxCollider2D>().bounds.size.y;
       
    }

    // Update is called once per frame
    void Update()
    {


        Move();
        Reposition();
    }

    void Reposition()
    {
        if (transform.position.y < cameraY)
        {
            float highbounY = köseler[0].transform.position.y;
            for (int i = 1; i < köseler.Length; i++)
            {
                if (highbounY < köseler[i].transform.position.y)
                {
                    highbounY = köseler[i].transform.position.y;

                }
            }
            Vector3 temp = transform.position;
            temp.y = highbounY + köseYükseklik - 1f;
            transform.position = temp;
        }

    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= SolKösehiz * Time.deltaTime;
        transform.position = temp;
    }
}
