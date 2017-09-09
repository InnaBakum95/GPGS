using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwPower : MonoBehaviour {

    public GameObject Dragonpower;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "cannonBall")
        {
           //Instantiate(Dragonpower, transform.position, transform.rotation);
          
        }
    }
}
