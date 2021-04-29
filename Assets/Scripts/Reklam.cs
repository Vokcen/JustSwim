using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Reklam : MonoBehaviour,IUnityAdsListener
{
    public static Reklam instance;
    private string gameID = "4087075";
    private string Altın = "Altin";
    private string ikiAltın = "ikiAltin";
    private string banner = "banner";
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
       
   
        StartCoroutine(ShowGecisReklam());
        StartCoroutine(ShowBannerWhenInitialized());     

    }
    
    IEnumerator ShowGecisReklam()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Show(Altın);
    }
    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_LEFT);
        Advertisement.Banner.Show(banner);
       
       
    }

    // Update is called once per frame
    void Update()
    {

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
    }
    public void İkiAltinButton()
    {
        if (Advertisement.IsReady(ikiAltın))
        {
            Advertisement.Show(ikiAltın);
     
        }
        else
        {
            Debug.Log("ikiyüz altın yüklenemedi");
        }
    }
    public void BannerBtn()
    {
        if (Advertisement.IsReady(banner))
        {
         

            Advertisement.Banner.Show(banner);
        }
        else
        {
            Debug.Log("banner yüklenemedi");
        }
    }
   
    public void BannerKapa()
    {

        Advertisement.Banner.Hide();

    }


    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished  )
        {
           
                
            // Reward the user for watching the ad to completion.
        }
       else if (showResult == ShowResult.Skipped)
        {

            Debug.Log("Skipledi");
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
    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Hazır:" + placementId);
    }
    
}
