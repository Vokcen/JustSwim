using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAD : MonoBehaviour, IUnityAdsListener
{
    public GameObject Ödülpaneli;
    public static RewardedAD instance;
    private string gameID = "4087075";

    private string Altın = "Altin";
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
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, true);
        Ödülpaneli.SetActive(false);
    }

    public void YuzAltinButton()
    {
        if (Advertisement.IsReady(Altın))
        {
            Advertisement.Show(Altın);

        }
        else
        {
            Debug.Log("altın yüklenemedi");
        }
    }// Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished|| showResult == ShowResult.Skipped)
        {

            
            Ödülpaneli.SetActive(true);
            Hak.kalanCan = 2;
            Hak.instance.BitisPaneli.SetActive(false);
            Time.timeScale = 1;
           

                // Reward the user for watching the ad to completion.
        }
  
        // Do not reward the user for skipping the ad.

        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }
    
        
    


    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
        Debug.Log("Error oldu" + message);
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
        Debug.Log("Reklam başlatıldı" + surfacingId);
    }
    public void OnUnityAdsReady(string surfacingId)
    {
        Debug.Log("Hazır:" + surfacingId);
    }
    public void BtnOdl()
    {
        Time.timeScale = 1;
        Hak.kalanCan = 2;
        Ödülpaneli.SetActive(false);
    }
}
