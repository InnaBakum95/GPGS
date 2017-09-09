using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleEnemy : MonoBehaviour {

    public static float movespeed = 0.5f;
    public Vector3 userDirection = Vector3.forward;
    public float rayCastDistance;
   
    private float originOffSet = 0.5f;
   
   
    void Start() {
        //CannonHelath.cannonHealth = Cannon.GetComponent<CannonHelath>();
        //GameObject cannon = GameObject.Find("Cannon");
        CannonHelath cannonHealth = GetComponent<CannonHelath>();
        
    }

  
    void Update() {
        transform.Translate(userDirection * movespeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f); //-Vector2.up);
        Debug.DrawRay(transform.position, -Vector2.up, Color.red);
        if (hit.collider != null)
        {
            //print(" " + hit.collider.gameObject.name);
            Debug.Log("hits");
             // movespeed = 0;
            //transform.Rotate(Vector3.left);
            //hit.collider.gameObject.name;

          
        }
        else
        {
           // movespeed = 0.5f;
           // movespeed = 0;
            Debug.Log("s");
            //transform.Rotate(Vector3.right * Time.deltaTime);
        }
    }
   
}

