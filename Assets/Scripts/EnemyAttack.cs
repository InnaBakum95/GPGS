using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int damageToGive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "cannon")
        {
            Debug.Log("Touched");
            coll.gameObject.GetComponent<CannonHelath>().TakeDamage(damageToGive);
        }

    }
}
