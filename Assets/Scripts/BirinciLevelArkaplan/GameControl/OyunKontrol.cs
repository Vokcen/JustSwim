using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] d�smanlar;
    int rand;
    int randposition;
    public static float starttimebtwspawn = 45f;
   public float timebtwSpawn;

    void Start()

    {
        timebtwSpawn =45f;


    }
    void Update()
    {



    }


    void FixedUpdate()
    {       

        if (timebtwSpawn <= 0)
        {
            rand = UnityEngine.Random.Range(0, d�smanlar.Length);
            randposition = UnityEngine.Random.Range(0, spawnpoints.Length);
            Instantiate(d�smanlar[rand], spawnpoints[randposition].transform.position, Quaternion.identity);
            timebtwSpawn = starttimebtwspawn;
        }
        else
        {
            timebtwSpawn -= Time.deltaTime;

        }




    }
    public float Str
    {
        get
        {
            return timebtwSpawn;
        }
        set
        {
            timebtwSpawn = value;
        }
    }

}
