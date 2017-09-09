using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteManager : MonoBehaviour {
    public static LevelCompleteManager Instance;
    public GameObject LevelCompletedScene;
    public GameObject LevelCompletedImage;
    public GameObject GameOverImage;
    public GameObject LevelCompletedText;
    public GameObject LevelFailedText;
    public GameObject NextButton;
    public GameObject Awards;
    public GameObject RewardBall;
    public GameObject But1;
    public GameObject but2;
    public GameObject CanonHealthManager;
    public GameObject NOLives;
   

    float timeLeft = 20.0f;
    public  int playerLives;
    public Text CurrentLife;
    public Text TImeText;
    public int CurrentLifes;
    public GameObject Time_Text;
    public bool Healing;
  
    void Start () {

        Time.timeScale = 1;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
      

        CurrentLifes = playerLives;
        CurrentLife.text = "Life : " + CurrentLifes.ToString();
        Time_Text.SetActive(false);
    }
	
	
	void Update () {

        if (Healing == true)
        {
            timeLeft -= Time.deltaTime;
            TImeText.text = "" + Mathf.Round(timeLeft);
            if (timeLeft < 0)
            {
                TImeText.enabled = false;
            }
        }
        if (Healing == false && CurrentLifes < playerLives)
        {
            StartCoroutine("waitForLife");

        }
    }
    public void LevelFailed()
    {

        CurrentLifes -= 1;

        CurrentLife.text = "Life : " + CurrentLifes.ToString();
    }
    IEnumerator waitForLife()
    {
        Healing = true;
       
        yield return new WaitForSeconds(timeLeft);

        CurrentLifes += 1;
        CurrentLife.text = "Life : " + CurrentLifes.ToString();
        Healing = false;
    }
    IEnumerator Failed()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.5f;
        LevelCompletedScene.SetActive(true);
        LevelCompletedImage.SetActive(false);
        LevelCompletedText.SetActive(false);
        GameOverImage.SetActive(true);
        LevelFailedText.SetActive(true);
        NextButton.SetActive(false);
        Awards.SetActive(false);
        RewardBall.SetActive(false);
        But1.SetActive(false);
        but2.SetActive(false);
        CanonHealthManager.SetActive(false);
     


    }
    public void LevelComp()
    {
        StartCoroutine("Completed");
    }
    IEnumerator Completed()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.5f;
        LevelCompletedScene.SetActive(true);
        LevelCompletedImage.SetActive(true);
        LevelCompletedText.SetActive(true);
        GameOverImage.SetActive(false);
        NextButton.SetActive(true);
        LevelFailedText.SetActive(false);
        Awards.SetActive(true);
        RewardBall.SetActive(true);
        But1.SetActive(false);
        but2.SetActive(false);
        CanonHealthManager.SetActive(false);
        Time.timeScale = 0.0f;
    }
    public void GotoShop()
    {
        SceneManager.LoadScene("testShopSCene");
    }
    public void GoToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ReplayLevel()
    {
        if (CurrentLifes > 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        else
        {
            NOLives.SetActive(true);
        }
        
    }
    public void NextLevel(string levename)
    {
       
        SceneManager.LoadScene(levename);
    }

    public void Killplayer()
    {
        
        
       // LifeText.text = ""+playerLives;
       
      
        Debug.Log("PlayerDead");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            
        
            LevelFailed();
            Time_Text.SetActive(true);
        }
    }
}
