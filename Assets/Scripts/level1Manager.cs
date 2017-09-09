using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level1Manager : MonoBehaviour {

    [System.Serializable]
    public class Level
    {
        public string LevelText;
        public int UnLocked;
        public bool IsInteractable;

        public Button.ButtonClickedEvent onclick;

    }

    public GameObject levelButton;
    public Transform Spacer;
    public List<Level> LevelList;
    void Start()
    {

        FillList();

    }

    void FillList()
    {
        foreach (var level in LevelList)
        {
            GameObject NewButton = Instantiate(levelButton) as GameObject;
            LevelButton button = NewButton.GetComponent<LevelButton>();
            button.leveltext.text = level.LevelText;
            if (PlayerPrefs.GetInt("Level" + button.leveltext.text) == 1)
            {
                level.UnLocked = 1;
                level.IsInteractable = true;
            }
            button.unlock = level.UnLocked;
            button.GetComponent<Button>().interactable = level.IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => Loadlevels("Level" + button.leveltext.text));
            if (PlayerPrefs.GetInt("Level" + button.leveltext.text + "_Score") > 100)
            {
                button.star1.SetActive(true);
                level.UnLocked = 1;
                level.IsInteractable = true;
            }
            if (PlayerPrefs.GetInt("Level" + button.leveltext.text + "_Score") >= 500)
            {
                button.star2.SetActive(true);
                level.UnLocked = 1;
                level.IsInteractable = true;
            }
            if (PlayerPrefs.GetInt("Level" + button.leveltext.text + "Score") >= 999)
            {
                button.star3.SetActive(true);
                level.UnLocked = 1;
                level.IsInteractable = true;
            }
            NewButton.transform.SetParent(Spacer);
        }
        SaveAll();
    }
    void SaveAll()
    {
        // if(PlayerPrefs.HasKey("Level1"))
        //{
        // return;
        //}
        // else
        // {
        GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        foreach (GameObject buttons in allButtons)
        {
            LevelButton button = buttons.GetComponent<LevelButton>();//calling of the button from the LevelButton
            //PlayerPrefs.SetInt("Level" + button.leveltext.text, button.unlock);
        }
        //}

    }
    //void deleteall()
    //{
    //    PlayerPrefs.DeleteAll();
    //}
    public void Loadlevels(string value)
    {
        SceneManager.LoadScene(value);
    }
}
