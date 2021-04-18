using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class YenidenOynanıs : MonoBehaviour
{
    public void YenidenOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
       
        Time.timeScale = 1;
    }

    public void AneMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }
    
}
