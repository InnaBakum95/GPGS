using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gainPowerups : MonoBehaviour {

	float moveSpeed = 8;
    public Rigidbody2D charRb;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float speed = moveSpeed * Time.deltaTime;
        charRb.AddForce(Vector2.down * moveSpeed,ForceMode2D.Impulse);
		Destroy (this.gameObject, 3);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "cannon")
        {
            Destroy(this.gameObject);
        }
    }
}
