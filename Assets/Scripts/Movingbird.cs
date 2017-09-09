using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingbird : MonoBehaviour {

    public float verticlaspeed;
    public float horizontalspeed;
    public float amplitude;
    private Vector3 tempPosition;
    
	// Use this for initialization
	void Start ()
    {
        tempPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {

        tempPosition.y += verticlaspeed;
        tempPosition.x += Mathf.Sin(Time.realtimeSinceStartup * horizontalspeed) * amplitude;
        transform.position = tempPosition;
    }
}
