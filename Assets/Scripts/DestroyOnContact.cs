﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
   
   
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemy")
        {
            return;
        }
       
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
