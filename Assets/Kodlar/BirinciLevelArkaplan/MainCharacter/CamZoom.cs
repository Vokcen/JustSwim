using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    public static int  ZoomActive;
    public Vector3[] Hedef;
    public Camera Cam;
    public float Aci;   
    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (ZoomActive==1)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 10, Aci);
            Cam.transform.position =  Vector3.Lerp(Cam.transform.position, Hedef[1], Aci);    
        }
        if(ZoomActive==0) 
        {

            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 5, Aci);
            Cam.transform.position =  Vector3.Lerp(Cam.transform.position, Hedef[0], Aci);


        }
        if(ZoomActive==2)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 15, Aci);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Hedef[2], Aci);
        }
    }
}
