using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_GP : MonoBehaviour {

    public Text Gold;
    public Text Enemies;
    public Text Level;


    private void Awake()
    {
     
    }



    // Use this for initialization
    void Start ()
    {
        GPGS_manager.Instance.LoadGame();
        Gold.text = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CountCollectedCoins).ToString();

        Enemies.text = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CountKillEnemies).ToString();

        Level.text = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CurrentLevel).ToString();

    }

    public void AddGold()
    {
        GPGS_manager.Instance.ach_collectCoins++;
        PlayerPrefs.SetInt(VariablesSaveOnPlayerPrefs.CountCollectedCoins, PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CountCollectedCoins)+1);
        Gold.text = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CountCollectedCoins).ToString();
        GPGS_manager.Instance.SaveGame();
        GPGS_manager.Instance.UploadData();
    }

    public void AddEnemies()
    {
        GPGS_manager.Instance.ach_killEnemies++;
        PlayerPrefs.SetInt(VariablesSaveOnPlayerPrefs.CountKillEnemies, PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CountKillEnemies) + 1);
        Enemies.text = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CountKillEnemies).ToString();
        GPGS_manager.Instance.SaveGame();
        GPGS_manager.Instance.UploadData();
    }
    public void AddLevel()
    {
        PlayerPrefs.SetInt(VariablesSaveOnPlayerPrefs.CurrentLevel, PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CurrentLevel) + 1);
        Level.text = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CurrentLevel).ToString();
        GPGS_manager.Instance.SaveGame();
    }

    
}
