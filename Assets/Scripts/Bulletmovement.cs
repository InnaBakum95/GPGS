using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmovement : MonoBehaviour {

    public float speed;
    
    
	void Start ()
    {
		
	}
	
	
	void Update()
    {   
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
