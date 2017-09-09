using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonHelath : MonoBehaviour {
    public float startingHealth;
    public float currentHealth;

    public Image healthBar;
   
    void Start () {
        currentHealth = startingHealth;
    }
	

	void Update () {
        if (currentHealth <= 0)
        { 
            Destroy(this.gameObject);

        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        healthBar.fillAmount = currentHealth / startingHealth;
    }
}
