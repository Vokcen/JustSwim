using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YuksekSkor : MonoBehaviour
{
    private int yuksekSkor;
    private TextMeshProUGUI TextMeshHighScore;

    private void Start()
    {
        TextMeshHighScore = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        yuksekSkor = PlayerPrefs.GetInt("YüksekSkor", 0);
        TextMeshHighScore.SetText(yuksekSkor.ToString());
    }
}
