using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    int score = 200;
	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.SetInt("Level1", 1);
        PlayerPrefs.SetInt("Level1_Score", score);
        StartCoroutine(Time());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Time()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level1");
    }
}
