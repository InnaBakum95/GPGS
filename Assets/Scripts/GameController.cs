using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnValues;
    public float waitwave;
    public float startWait;
    public float spawnwait;

     void Start()
    {
        StartCoroutine (SpawnWaves());
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            int random = Random.Range(0, spawnValues.Length);
            for (int i = 0; i < spawnValues.Length; i++)
            {
                if (random != i)
                {
                    Instantiate(enemy, spawnValues[i].position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnwait);
                }
            }
            yield return new WaitForSeconds(waitwave);
        }
        
    }
}
