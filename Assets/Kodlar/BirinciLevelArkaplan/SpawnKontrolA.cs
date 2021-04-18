using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKontrolA : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] düsmanlar;
    int rand;
    int randposition;
    [SerializeField] float starttimebtwspawn;
    float timebtwSpawn;

    void Start()

    {
        timebtwSpawn = starttimebtwspawn;


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
   

}
