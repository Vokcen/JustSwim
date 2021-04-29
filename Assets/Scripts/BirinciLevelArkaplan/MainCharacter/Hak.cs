    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Hak : MonoBehaviour
{
    public static Hak instance;

   
    public static int kalanCan, MaxCan;
    public int kalpSay�;
    public Image[] kalpler;
    public Sprite Dolucan;
    public Sprite Bo�can;
   // public TextMeshProUGUI Hakyazisi;

    public GameObject BitisPaneli;
    public GameObject Kalanhakyazi, skoryazi;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        BitisPaneli.SetActive(false);
      


    }

  
    void Update()
    {
        

      
        if (kalanCan <= 0) kalanCan = 0;
       

       // Hakyazisi.text = "Can:" + kalanCan.ToString();
        if (kalanCan <= 0)
        {
            BitisPaneli.SetActive(true);
            Time.timeScale = 0;
        }
        if (kalanCan>kalpSay�)
        {
            kalanCan = kalpSay�;
        }
        for (int i = 0; i < kalpler.Length; i++)
        {
            if (i<kalanCan)
            {
                kalpler[i].sprite = Dolucan;
            }
            else
            {
                kalpler[i].sprite = Bo�can;
            }
            if (i<kalpSay�)
            {
                kalpler[i].enabled = true;
            }
            else
            {
                kalpler[i].enabled = false;
            }

        }
       
    }
    public void BtnOdl()
    {
        Time.timeScale = 1;
       kalanCan = 2;
     
    }


}
