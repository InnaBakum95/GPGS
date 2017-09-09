using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SavingAndLoading : MonoBehaviour {

    bool userHasPlayedBefore = false;
    public int InitialCoin;
    //public int CurrentCoin;
    int CurrentXp;
    public int Currentkills;
    public static int currentlevel;
    LevelSystem mylevel;
    public Text TotalCointext;

    private void Start()
    {
        TotalCointext.text = "Coin: " + Coin.coin;
        mylevel = FindObjectOfType<LevelSystem>();
        LoadAllValues();
        userHasPlayedBefore = PlayerPrefs.GetString("playerHasplayedBefore").ToString().ToLowerInvariant() == "yes";

        if (userHasPlayedBefore == true)
        {
            LoadAllValues();
        }
        else
        {
            InitialCoin = 0;
            SaveAllValues();
        }

        DontDestroyOnLoad(this.gameObject);
    }
    
    // Update is called once per frame
    void Update ()
    {
        
        //SaveAllValues();
        
    }
    void SaveAllValues()
    {
        //CurrentCoin = Coin.coin;
        //Currentkills = ScoreManager.score;
        //CurrentXp = Xp.XpValue;
        PlayerPrefs.SetInt("coins", Coin.coin);
        PlayerPrefs.SetInt("kills", ScoreManager.score);
        PlayerPrefs.SetInt("xp", Xp.XpValue);
       // PlayerPrefs.SetInt("level", mylevel.currentLevel);
        userHasPlayedBefore = true;
        PlayerPrefs.SetString("playerHasplayedBefore", "yes");
    }
    void LoadAllValues()
    {
        Coin.coin = PlayerPrefs.GetInt("coins");
        Xp.XpValue = PlayerPrefs.GetInt("xp");
        ScoreManager.score = PlayerPrefs.GetInt("kills");
        //mylevel.currentLevel = PlayerPrefs.GetInt("level");
        
    }
}
