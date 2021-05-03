using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finger : MonoBehaviour
{
    //[SerializeField] SpriteRenderer playerImage;
    [SerializeField] GameObject[] skins;
    private Vector3 TouchPosition;
    private Rigidbody2D rb;
    private Vector3 Direction;
    public float movespeed = 10f;
  
    private Vector3 ScaleChange;
 
    private void Awake()
    {
        ScaleChange = new Vector3(1f, 1f, 1f);
    }
    void Start()
    {
       

        rb = GetComponent<Rigidbody2D>();
        ChangePlayerSkin();
    }
    void ChangePlayerSkin()
    {
        Chacter chacter = GameDataManager.GetSelectedChacter();
        if (chacter.image != null)
        {
            // playerImage.sprite = chacter.image;

            //get selected chacteer index:
            int selectedSkin =  GameDataManager.GetSelectedChacterIndex();
            // show selected skins gameobjectt:
            skins[selectedSkin].SetActive(true);
            //hide other skins(execpt selected skin):
            for(int i=0; i<skins.Length; i++)
            if(i !=selectedSkin)
                    skins[i].SetActive(false);
            


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            TouchPosition.z = 0;
            Direction = (TouchPosition - transform.position);
            rb.velocity = new Vector2(Direction.x, Direction.y)* movespeed;

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero; 
            

        }
        if (CamZoom.ZoomActive>=2)
        {
          
            transform.localScale = ScaleChange;
          

        }


    }
    
}
