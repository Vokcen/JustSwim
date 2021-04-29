using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class K�seHareket : MonoBehaviour
{
    Engeller eng = new Engeller();
    public static float k�sehizi = 5f;
    GameObject[] k�seler;
    float cameraY;
    float k�seY�kseklik;
        void Awake()
    {
        k�seler = GameObject.FindGameObjectsWithTag("K�seler");
        cameraY = Camera.main.transform.position.y-15;
        k�seY�kseklik = GetComponent<BoxCollider2D>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
     
       
        Move();
        Reposition();
      }

     void Reposition()
    {
        if (transform.position.y<cameraY) 
        {
            float highbounY = k�seler[0].transform.position.y;
            for (int i = 1; i < k�seler.Length; i++)
            {
                if (highbounY<k�seler[i].transform.position.y)
                {
                    highbounY = k�seler[i].transform.position.y;

                }
            }
            Vector3 temp = transform.position;
            temp.y = highbounY + k�seY�kseklik -  1f;
            transform.position = temp;
        }

    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= k�sehizi * Time.deltaTime;
        transform.position = temp;
     }
}
