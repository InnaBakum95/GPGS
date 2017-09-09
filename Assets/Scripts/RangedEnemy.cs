using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour {
  
    public Transform spawnPoint;
    public GameObject bullet;
    bool canShoot = true;


    public static float movespeed = 0.5f;
   public Vector3 userDirection = Vector3.forward;

    void Start () {
       
	}
	

	void Update () {
        if (canShoot == true)
        { 
            StartCoroutine("waitforShoot");
            shootBullet();
        }
        
        transform.Translate(userDirection * movespeed * Time.deltaTime);
    }

    IEnumerator waitforShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
    void shootBullet()
    {
        StartCoroutine("waitforShoot");
        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stop")
        {
            Debug.Log("Enemy");
            movespeed = 0f;
        }
    }
}