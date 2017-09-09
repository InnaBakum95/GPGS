using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBar : MonoBehaviour {

    public int totalHealth;
    int currentHp;

	// Use this for initialization
	void Start () 
    {
        currentHp = totalHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHp <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    public void takeDamage(int damage)
    {
        currentHp -= damage;
    }
}
