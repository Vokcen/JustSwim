using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Puan : MonoBehaviour
{
    public GameObject puanalma;
    Engeller engel = new Engeller();
    public Animator ani;
    public GameObject efekt;
    public AudioSource a;


    void OnCollisionEnter2D(Collision2D temas)
    {
            
        
        if (temas.gameObject.tag=="Karakter")
        {
            Hak.kalanCan += 1;
            StartCoroutine(WaitBeforeShow());


        }
        if (temas.gameObject.tag=="Zemin")
        {
            Destroy(this.gameObject);
        }


    }
    void Start()
    {

        ani.enabled = false;

        a = GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }
    IEnumerator WaitBeforeShow()
    {
        ani.enabled = true;
        a.Play();
         Instantiate(efekt, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);

    }
}
