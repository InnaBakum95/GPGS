using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.UpArrow))
        {
            Instantiate(bullet, transform.position,transform.rotation);
            
        }
	}
}
