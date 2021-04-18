using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    #region SIngleton:Game
    public static Game Instance;
     void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        }
    #endregion
    public int coins;
    public void UseCoins(int amount)
    {
        coins -= amount;
    }
    public bool HasEnoughCoins(int amount)
    {
        return (coins >= amount);
    }
}





