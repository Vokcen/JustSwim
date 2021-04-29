using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kaliteayarı : MonoBehaviour
{
    public Dropdown Kalite;
       private void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Kalite"));
        Kalite.value = PlayerPrefs.GetInt("Kalite");

    }

    public void KaliteSecint(int İstenilenKalite)
    {
        PlayerPrefs.SetInt("Kalite",İstenilenKalite);
        QualitySettings.SetQualityLevel(İstenilenKalite);
    }

        
}
