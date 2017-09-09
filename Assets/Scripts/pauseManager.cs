using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour {

    [SerializeField] private GameObject pausePanel;
    public GameObject pauseButton;
  
    void Start () {
        pausePanel.SetActive(false);

    }
	
	
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (!pausePanel.activeInHierarchy)
        //    {
        //        PauseGame();
        //    }
        //    if (pausePanel.activeInHierarchy)
        //    {
        //        ContinueGame();
        //    }
        //}
    }
    public void PauseGame()
    {
        Time.timeScale = 0.1f;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void GoToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
}
