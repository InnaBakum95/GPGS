 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform[] spawnpoints;
    public float spawntime;
    public GameObject[] foe;

    void Start()
    {
        InvokeRepeating("spawncoins", spawntime, spawntime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawncoins()
    {
        int spawnIndex = Random.Range(0, spawnpoints.Length);
        int foeIndex = Random.Range(0, foe.Length);
        Instantiate(foe[foeIndex], spawnpoints[spawnIndex].position, Quaternion.identity);
    }

}
