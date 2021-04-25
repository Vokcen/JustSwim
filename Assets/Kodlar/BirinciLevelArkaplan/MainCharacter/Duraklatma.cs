using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Duraklatma : MonoBehaviour
{
    public static Duraklatma instance;
    public GameObject pausep;
    public  int deger;
    Engeller Engel = new Engeller();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

        void Start()
    {
       Engel.Score = 0;
        Hak.kalanCan = 4;
        pausep.SetActive(false);
        deger = PlayerPrefs.GetInt("level");
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public void butondan_gelen(string ne_Geldi)
    {

        if (ne_Geldi == "Pause")
        {
            pausep.SetActive(true);
            Time.timeScale = 0;

        } 
        else if (ne_Geldi == "devamet")
        {
            pausep.SetActive(false);
            Time.timeScale = 1;
        }
        else if (ne_Geldi == "LevelEkraný")
        {
            SceneManager.LoadScene("LevelSahnesi");
        }
        else if (ne_Geldi == "AnaMenü")
        {
            SceneManager.LoadScene("Main");
        }
        
        else if (ne_Geldi == "YenidenBasla")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else if (ne_Geldi == "Level1gecis")
        {
            SceneManager.LoadScene("Baslangic");

        }
        else if (ne_Geldi == "Eglence")
        {
            SceneManager.LoadScene(2);
        }


    }
    public void  hangi_level(int level)
    {
        deger = level ; 
        PlayerPrefs.SetInt("level",deger);
    }
 

   
}
