﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("up"))
        {
            Time.timeScale = 4;
        }
        if (Input.GetKeyUp("down"))

        {
            Time.timeScale = 28;
        }
        if (Input.GetKeyUp("right"))

        {
            Time.timeScale = 1;
        }
    }
}
