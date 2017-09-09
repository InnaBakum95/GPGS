using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShoot : MonoBehaviour {

    public GameObject cannonBall;
    public Transform ShotSpawn;
    public AudioSource shotaudio;

    bool canAttack = true;
   
    // Use this for initialization
    void Start () {
        shotaudio = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        Instantiate(cannonBall, ShotSpawn.position, ShotSpawn.rotation);
        shotaudio.Play();
        StartCoroutine("waitforAttack");
    }
    IEnumerator waitforAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
