using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void click()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void Settings()
    {
        SceneManager.LoadScene("testShopSCene");
    }
    public void AboutUs()
    {
        Debug.Log("About US");
    }
    public void goBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Achivements()
    {
        SceneManager.LoadScene("Achivements");
    }
    
}
