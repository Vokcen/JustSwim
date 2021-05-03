using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using UnityEngine.UI;

public class Engeller : MonoBehaviour
{
    OyunKontrol s = new OyunKontrol();
    [SerializeField]int y�ksekSkor;
    [SerializeField] float  skor;
 
    public TextMeshProUGUI Skoryazisi,BitisYazisi;
   [SerializeField]TextMeshProUGUI Y�ksekSkorYazisi;
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
        y�ksekSkor = PlayerPrefs.GetInt("Y�ksekSkor", 0);
        ripple = Camera.main.GetComponent<RipplePostProccessor>();
        Y�ksekSkorYazisi.text = "" + y�ksekSkor.ToString();

      
    }



        void Update()
        {
        if (skor <= 1)
        {
            CamZoom.ZoomActive = 0;
            OyunKontrol.starttimebtwspawn = 50f;
            Oyunkontrol�.starttimebtwspawn = 2f;
       

        }

        if (skor > 30)
        {
         
            skor += Time.deltaTime * 1.5f;
            Oyunkontrol�.starttimebtwspawn = 0.7f;
           
        }
        if (skor > 60)
        {
            OyunKontrol.starttimebtwspawn = 0.5f;
            CamZoom.ZoomActive = 1;
            ripple.friction();
          

            Oyunkontrol�.starttimebtwspawn = 999f;

        }

        if (skor > 120)
        {
            OyunKontrol.starttimebtwspawn = 0.2f;
            skor += Time.deltaTime * 2;


        }
        if (skor > 180)
        {
            OyunKontrol.starttimebtwspawn = 999f;
        }
        if (skor >= 202)
        {
            WaweThree.starttimebtwspawn = 0.5f;
            skor += Time.deltaTime *2.5f;
            CamZoom.ZoomActive = 2;
            ripple.frictionA();





        }
        if (skor >= 260)
        {
                        WaweThree.starttimebtwspawn = 0.5f;



        }
        if (skor >= 300)
        {
            WaweThree.starttimebtwspawn = 0.4f;
            skor += Time.deltaTime * 3;

        }


        if (Hak.kalanCan <= 0)
            {
                Time.timeScale = 0;
            }

         if(y�ksekSkor<skor)
        {
          
            PlayerPrefs.SetInt("Y�ksekSkor", (int)skor);
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
