using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelectAndUnlock : MonoBehaviour {
    [System.Serializable]
	public class Level
    {
        public string LevelText;
        public int UnLocked;
        public bool IsInteractable;
   
    }
    public GameObject Levelbutton;
    public Transform Spacer;
    public List<Level> LevelList;
    

	void Start ()
    {
        //deleteall();
        FillList();
	}
	
	void FillList()
    {
        foreach(var level in LevelList)
        {
            GameObject Newbutton = Instantiate(Levelbutton) as GameObject;
        
            LevelButton btn = Newbutton.GetComponent<LevelButton>();//calling of the Levelbutton

            btn.leveltext.text = level.LevelText;//leveltext is called from LevelButton Script and level.LevelText is of this same script.

            if(PlayerPrefs.GetInt("Level"+ btn.leveltext.text)==1)
            {
                level.UnLocked = 1;
                level.IsInteractable = true;
            }
            btn.unlock = level.UnLocked;
            btn.GetComponent<Button>().interactable = level.IsInteractable;
            btn.GetComponent<Button>().onClick.AddListener(() =>Loadlevels("Level" + btn.leveltext.text));
            if(PlayerPrefs.GetInt("Level"+ btn.leveltext.text+"_score")>0)
            {
                btn.star1.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Level" + btn.leveltext.text + "_score") >= 500)
            {
                btn.star2.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Level" + btn.leveltext.text + "_score") >=999)
            {
                btn.star3.SetActive(true);
            }
            Newbutton.transform.SetParent(Spacer);
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
                PlayerPrefs.SetInt("Level" + button.leveltext.text, button.unlock);
            }
        //}
       
    }
    //void deleteall()
    //{
    //    PlayerPrefs.DeleteAll();
    //}
    public  void Loadlevels(string value)
    {
        SceneManager.LoadScene(value);
    }

}
