using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
public class saveSystem : MonoBehaviour {

    [System.Serializable]
    public class saving
    {
        public List<powerupData> shopList = new List<powerupData>();
        public int coin;
       
    }

    public void saveData()
    {
     
        saving save = new saving();
        save.coin = gameManager.manager.getgoldInfo();

        //add powerups
        for (int i = 0; i < shopManager.instance.powerupList.Count; i++)
        {
            save.shopList.Add(shopManager.instance.powerupList[i]);
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/shop.octo", FileMode.Create);

        formatter.Serialize(stream, save);
        stream.Close();
        print("save");
        SceneManager.LoadScene("MainMenu");
    }

    public void loadData()
    {
        if (File.Exists(Application.persistentDataPath + "/shop.octo"))
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/shop.octo", FileMode.Open);

            saving sdata = (saving)bFormatter.Deserialize(stream);
            gameManager.manager.setgoldInfo(sdata.coin);

            stream.Close();
            print("Load");
            for (int i = 0; i <sdata.shopList.Count; i++)
            {

                //Update shop
                shopManager.instance.powerupList[i] =sdata.shopList[i];

                //Update sprite
                shopManager.instance.updateSprite(shopManager.instance.powerupList[i].powerupID);
            }
        }
    }
}
