﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    //public float moveSpeed;
    //public Rigidbody2D rb;
    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.right;
   // Use this for initialization

   void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(userDirection * movespeed * Time.deltaTime);
    }
}
