using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyTime : MonoBehaviour {

    int score = 1000;
     //Use this for initialization
      void Start ()
    {
        PlayerPrefs.SetInt("Level2", 1);
        PlayerPrefs.SetInt("Level1_Score", 700);
        StartCoroutine(LoadTime());
}

// Update is called once per frame
void Update()
{

}
IEnumerator LoadTime()
{
    yield return new WaitForSeconds(2f);
    SceneManager.LoadScene("Level2");
}
}
