using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;
    public GameObject explosion;
   
   
    

    void Start()
    {


    }

    void Update()
    {

        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        Destroy(this.gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}





