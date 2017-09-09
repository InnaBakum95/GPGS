using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zicZacMovement : MonoBehaviour {
    public float moveSpeed;
    public float walkspeed;
    private Rigidbody2D myRigidbody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDIrection;

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
	}
	
	// Update is called once per frame
	void Update () {

      
       
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
           
            switch (walkDIrection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(moveSpeed,0);
                    break;

                case 1:

                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }
            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
           
            {

            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (waitCounter<0)
            {
                ChooseDirection();
            }
        }
	}
    public void ChooseDirection()

    {
        walkDIrection = Random.Range(0, 2);
        isWalking = true;
        walkCounter = walkTime;
    }
}
