using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Karakter : MonoBehaviour
{
    public Animator karakter;
    public  float hiz = 5;
    bool hareket_ediyor;
    Rigidbody2D rb;
    public GameObject Paraefekt;

    void Awake()
    {
      
    }

    void Update()
    {
        if (hareket_ediyor)
        {
        transform.position += new Vector3(hiz, 0, 0) * Time.deltaTime;
        }
        
    }
    public void Hareket(bool sol_yonde_mi)
    {
        if (sol_yonde_mi)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                hiz *= -1;
            }           
        }
        else
        {
            if (transform.localScale.x < 0)
            { transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                hiz *= -1;
            }
        }
        hareket_ediyor = true;
    }
    public void Hareketbitis()
    {
        hareket_ediyor = false;
    }


     void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.collider.tag;
        if (tag.Equals("Coin"))
            //Coin ekler
        {
            Debug.Log("Deðdi");
            StartCoroutine(WaitBefore());

        }

    }
    IEnumerator WaitBefore()
    {
        Instantiate(Paraefekt, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

    }




}



