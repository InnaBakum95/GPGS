using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D charRb;
    public float speed;
    public int damageToGive = 1;


    void Start()
    {
        Destroy(gameObject, 5f);
        charRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        charRb.AddForce(Vector2.down * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "cannon")
        {
            other.gameObject.GetComponent<CannonHelath>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }
     
    }
    }
