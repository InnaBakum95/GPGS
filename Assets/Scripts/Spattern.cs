using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spattern : MonoBehaviour {
    
    public float speed;
    public float sinAmplitude;
    public float sinFrequency;
    private float time;
    private float horizontalOffset = 0.0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        time = Time.deltaTime*sinAmplitude;
        //move offset from enemy
        transform.position -= horizontalOffset * transform.right;

        //move enemyforward
        transform.position += transform.up * speed * Time.deltaTime;

        //Adjust horizontal position by Sine wave
        horizontalOffset = Mathf.Sin(time*sinFrequency*2*Mathf.PI)*sinAmplitude;

        transform.position += horizontalOffset * transform.right;
        
    }
}

