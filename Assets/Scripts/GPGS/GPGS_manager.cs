using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using System.Text;
using UnityEngine;

public class GPGS_manager : MonoBehaviour {


    public static GPGS_manager Instance;



    //Achievements

    //When count Coins or count kill enemies Changes coll
    //GPGS_manager.Instance.ach_collectCoins += "Changes value"
    //GPGS_manager.Instance.ach_killEnemies += "Changes value"
    public int ach_collectCoins;
    public int ach_killEnemies;



    //cloud save system
    private ISavedGameMetadata currentMetadata;
    private static SaveData _currentSaveData;
    private const string saveFilename = "SaveGameTop";
    private bool _isLoading = false;
    private bool _isSaving = false;

    //friends and gift
    public Texture2D coinIcon;
    private const string COIN_GIFT_ID = "COIN";


    private void Awake()
    {
        Instance = this;

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        InitIncrementalVariables();
        SignIn();
        DontDestroyOnLoad(gameObject);
    }


    //Autorization Users
    void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate((bool success) =>
        {
            if (success)
            {
                UploadData();
            }
        }, false);
    }


    #region Friends and Gifts

    //call when load friends list
    public void LoadFriendsGP()
    {
         GooglePlayManager.Instance.LoadFriends();
    }


    //Call when send gift
    public void SendGiftRequest()
    {
        //arguments is example
        GooglePlayManager.Instance.SendGiftRequest(GPGameRequestType.TYPE_GIFT, 1, coinIcon, "Here is some pie", COIN_GIFT_ID);
    }




    #endregion Friends and Gigts

    #region Leaderboards and Achievements
    //Call this function when you wont show leaderboards 
    //like this: GPGS_manager.Instance.ShowLeaderboards
    public void ShowLeaderboards()
    {
        if (Social.localUser.authenticated)
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        else
            SignIn();
    }


    //Call this function when you wont show achievements 
    //like this: GPGS_manager.Instance.ShowAchievements
    public void ShowAchievements()
    {
        if (Social.localUser.authenticated)
            Social.ShowAchievementsUI();
        else
            SignIn();
    }




    public void AddScoreToLeaderboard(string leaderboard, int score)
    {
        Social.ReportScore(score, leaderboard, (bool success) =>
        {

        });
        
    }

    ////Call this function when variable for leaderboard and achievements has changed, for example:
    ////  GPGS_Manager.Instance.UploadData();
    
    public void UploadData()
    {
        //Leaderboard High score 
        AddScoreToLeaderboard(GPGSIds.leaderboard_high_score, PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.HighScore));
        //Leaderboard count collected coint
        AddScoreToLeaderboard(GPGSIds.leaderboard_most_money_earned, PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CountCollectedCoins));
        //Leaderboard most active player
        AddScoreToLeaderboard(GPGSIds.leaderboard_most_active_player,PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.MaxTimeGameSession));


        if (ach_collectCoins > 0)
        {

            //Achievement collected coins
            //Add achievements collected coins here
            ReportIncrementalAchievement(GPGSIds.achievement_collect_500_coins, ach_collectCoins, "Achievement Collected Coins");
            ReportIncrementalAchievement(GPGSIds.achievement_collect_1000_coins, ach_collectCoins, "Achievement Collected Coins");
            ReportIncrementalAchievement(GPGSIds.achievement_collect_2000_coins, ach_collectCoins, "Achievement Collected Coins");
            ReportIncrementalAchievement(GPGSIds.achievement_collect_3000_coins, ach_collectCoins, "Achievement Collected Coins");

        }
        if (ach_killEnemies > 0)
        {
            //Achievement kill enemies
            //Add achievements kill enemies here
            ReportIncrementalAchievement(GPGSIds.achievement_kill_100_enemies, ach_killEnemies, "Achievement Kill Enemies");
            ReportIncrementalAchievement(GPGSIds.achievement_kill_500_enemies, ach_killEnemies, "Achievement Kill Enemies");
            ReportIncrementalAchievement(GPGSIds.achievement_kill_1000_enemies, ach_killEnemies, "Achievement Kill Enemies");
            ReportIncrementalAchievement(GPGSIds.achievement_kill_2000_enemies, ach_killEnemies, "Achievement Kill Enemies");
        }

        ach_collectCoins = 0;
        ach_killEnemies = 0;
    }



    private void ReportIncrementalAchievement(string achievementID, int progress, string saveName)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(achievementID, progress, (bool success) =>
        {
            if (success)
                PlayerPrefs.DeleteKey(saveName);
            else
                PlayerPrefs.SetInt(saveName, progress);
        });
    }

    
    private void InitIncrementalVariables()
    {
        ach_collectCoins = PlayerPrefs.GetInt("Achievement Collected Coins");
        ach_killEnemies = PlayerPrefs.GetInt("Achievement Kill Enemies");
    }
    #endregion Leaderboards and Achievements

    #region Cloud Save System
    
    
    // Save data on google cloud
    //For example, where variable has changed, you need save changes in Player Prefs, and then call function SaveGame! 
    //Const string variable you can see in scripts VariableSaveOnPlayerPrefs.cs
    //PlayerPrefs.SetInt(VariablesSaveOnPlayerPrefs.CurrentLevel, variable);

    //Call when you need save data, using like this
    //GPGS_Manager.Instance.SaveGame();



    public void SaveGame()
    {
        #if !UNITY_EDITOR
                _isSaving = true;
                _isLoading = false;
                OpenSavedGame();
        #endif
    }


    //Call when you need read data(for example, when load first scene), using like this
    //GPGS_Manager.Instance.LoadGame();
    public void LoadGame()
    {
        #if !UNITY_EDITOR
                _isLoading = true;
                _isSaving = false;
                OpenSavedGame();
        #endif
    }

    public void OpenSavedGame()
    {
        try
        {
            currentMetadata = null;
            ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
            savedGameClient.OpenWithAutomaticConflictResolution(
                saveFilename,
                DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime,
                OnSavedGameOpened);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        try
        {
            if (status == SavedGameRequestStatus.Success)
            {
                currentMetadata = game;
                if (_isLoading)
                    ReadSaveGameData();

                if (_isSaving)
                    WriteSaveGameData(currentMetadata);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    void WriteSaveGameData(ISavedGameMetadata game)
    {
        try
        {
            ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;

            SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();
            builder = builder
                .WithUpdatedPlayedTime(game.TotalTimePlayed)
                .WithUpdatedDescription("Saved game at " + DateTime.Now);

            SavedGameMetadataUpdate updatedMetadata = builder.Build();

            SaveData saveData = new SaveData
            {
                CountCoins = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CountCollectedCoins),
                CurrentLevel = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CurrentLevel),
                TimeSession = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.MaxTimeGameSession),
                CountKillEnemies = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.CountKillEnemies),
                HighScore = PlayerPrefs.GetInt(VariablesSaveOnPlayerPrefs.HighScore)


            };

            string json = JsonUtility.ToJson(saveData);
            savedGameClient.CommitUpdate(game, updatedMetadata, JsonStringToByteArray(json), OnSavedGameWritten);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void OnSavedGameWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        _isSaving = false;
    }

    public void ReadSaveGameData()
    {
        try
        {
            ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
            savedGameClient.ReadBinaryData(currentMetadata, OnSavedGameDataRead);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] data)
    {
        try
        {
            if (status == SavedGameRequestStatus.Success)
            {
                string json = JsonStringFromByteArray(data);
                SaveData saveData = JsonUtility.FromJson<SaveData>(json);
                _currentSaveData = saveData;

                PlayerPrefs.SetInt(VariablesSaveOnPlayerPrefs.CurrentLevel, _currentSaveData.CurrentLevel);
                PlayerPrefs.SetInt(VariablesSaveOnPlayerPrefs.MaxTimeGameSession, _currentSaveData.TimeSession);
                PlayerPrefs.SetInt(VariablesSaveOnPlayerPrefs.CountCollectedCoins, _currentSaveData.CountCoins);
                PlayerPrefs.SetInt(VariablesSaveOnPlayerPrefs.CountKillEnemies, _currentSaveData.CountKillEnemies);
                PlayerPrefs.SetInt(VariablesSaveOnPlayerPrefs.HighScore, _currentSaveData.HighScore);


            }
            else
            {
                Debug.LogWarning("Error reading game: " + status);
            }

            _isLoading = false;

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public static byte[] JsonStringToByteArray(string jsonString)
    {
        byte[] encodedString = Encoding.UTF8.GetBytes(jsonString);
        return encodedString;
    }

    static string JsonStringFromByteArray(byte[] bytes)
    {
        string decodedString = Encoding.UTF8.GetString(bytes);
        return decodedString;
    }



    #endregion Cloud Save System

}
