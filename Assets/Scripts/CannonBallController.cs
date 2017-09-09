using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;
    public GameObject explosion;
    public int scoreValue = 1;
    int damageToGive = 10;

    void Start()
	{


	}

    void Update ()
    {
		
		rb.AddForce(Vector2.up *speed, ForceMode2D.Impulse);
        Destroy(this.gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy" || other.tag== "AbnormalEnemy" || other.tag=="rangeEnemy")
        {

            ScoreManager.score += scoreValue;
            other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damageToGive);
           
            Destroy(this.gameObject);
            //Instantiate(explosion, transform.position, transform.rotation);
        }      
    }
}
