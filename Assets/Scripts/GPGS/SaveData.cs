using GooglePlayGames.BasicApi;
using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]


public class SaveData
{


    //Variables that we save on google cloud
    public int CurrentLevel;
    public int CountCoins;
    public int CountKillEnemies;
    public int HighScore;
    public int TimeSession;

}
