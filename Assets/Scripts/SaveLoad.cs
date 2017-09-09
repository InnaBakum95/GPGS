using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour {

    public static SaveLoad control;
      public int currentXp;
    public int currentExperience;
	void Awake ()
    {
		if(control==null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control!=this)
        {
            Destroy(gameObject);
        }

	}
	public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");
        PlayerData data = new PlayerData();
        data.currentXp = currentXp;
        data.currentExperience = currentExperience;
        bf.Serialize(file, data);
        file.Close();

    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat",FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            currentXp = data.currentXp;
            currentExperience = data.currentExperience;
        }
        else
        {
            Debug.Log("File doesn't exist.");
            
        }
    }
    [Serializable]
    class PlayerData
    {
        public int currentXp;
        public int currentExperience;
    }
}
