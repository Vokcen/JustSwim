using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using UnityEngine.UI;

public class Engeller : MonoBehaviour
{
    [SerializeField]int yüksekSkor;
    [SerializeField] float  skor;
 
    public TextMeshProUGUI Skoryazisi,BitisYazisi;
   [SerializeField]TextMeshProUGUI YüksekSkorYazisi;
    private  int hakDegeri=1;
    public Camera Cam;
   public float speed;
    public Vector3[] target;
    public bool zoomactive;
    private RipplePostProccessor ripple;
    public AudioClip newTrack;
    private SesKontrol theAM;
    public Rigidbody2D rg;
   
    void Start()

    {
       
        theAM = FindObjectOfType<SesKontrol>();
        Cam = Camera.main;
        Time.timeScale = 1;
        yüksekSkor = PlayerPrefs.GetInt("YüksekSkor", 0);
        ripple = Camera.main.GetComponent<RipplePostProccessor>();
        YüksekSkorYazisi.text = "" + yüksekSkor.ToString();

      
    }





    void FixedUpdate()
    {
        if (skor <=1)
        {
            CamZoom.ZoomActive = 0;
            OyunKontrol.starttimebtwspawn = 999;
            Oyunkontrolü.starttimebtwspawn = 1f;

        }

        if (skor >= 30)
        {

            skor += Time.deltaTime * 1.5f;
            Oyunkontrolü.starttimebtwspawn = 0.7f;
        }
        if (skor >= 80)
        {
            CamZoom.ZoomActive = 1;
            ripple.friction();
            OyunKontrol.starttimebtwspawn = 0.6f;
            Oyunkontrolü.starttimebtwspawn = 999f;

        }

        if (skor >= 120)
        {
            OyunKontrol.starttimebtwspawn = 0.4f;
            skor += Time.deltaTime * 2;
         

        }
        if (skor >= 200)
        {
           
            ripple.frictionA();
          
        



        }
        if (skor >= 250)
        {



        }
        if (skor >= 300)
        {
            OyunKontrol.starttimebtwspawn = 0.3f;

            Oyunkontrolü.starttimebtwspawn = 6f;
            skor += Time.deltaTime * 3;

        }
        if (skor >= 350)
        {

           
          

        }
    }
        void Update()
        {


            if (Hak.kalanCan <= 0)
            {
                Time.timeScale = 0;
            }

         if(yüksekSkor<skor)
        {
          
            PlayerPrefs.SetInt("YüksekSkor", (int)skor);
        }

            skor += Time.deltaTime;
            Skoryazisi.text = (int)skor + "M";
            BitisYazisi.text = "Oyun Bitti.  Skor:" + (int)skor;



        }
    
   
    public float Score
    {
        get
        {
            return skor;
        }
        set
        {
            skor = value;
        }
    }
    public int HakDegeri
    {
        get
        {
            return hakDegeri;
        }
        set
        {
            hakDegeri = value;
        }
    }
}
