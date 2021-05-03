using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyunkontrolü : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] düsmanlar;
    int rand;
    int randposition;
  public static float starttimebtwspawn = 2f;
  public  float timebtwSpawn;

    void Start()

    {
        timebtwSpawn = 2f;


    }
    void Update()
    {
       


    }
     
    
    void FixedUpdate()
    {
        if (timebtwSpawn <= 0)
        {
            rand = UnityEngine.Random.Range(0, düsmanlar.Length);
            randposition = UnityEngine.Random.Range(0, spawnpoints.Length);
            Instantiate(düsmanlar[rand], spawnpoints[randposition].transform.position, Quaternion.identity);
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
