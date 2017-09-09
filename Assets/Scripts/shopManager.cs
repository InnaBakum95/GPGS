using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    public static shopManager instance;

    public List<powerupData> powerupList = new List<powerupData>();

    private List<GameObject> itemHolderList = new List<GameObject>();

    public GameObject dataHolderPrefab;
    public Transform gridLocation;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
        fillList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void fillList()
    {
        for (int i = 0; i < powerupList.Count; i++)
        {
            GameObject powerHolder = Instantiate(dataHolderPrefab, gridLocation);

            dataHolder holder = FindObjectOfType<dataHolder>();

            holder.powerupName.text = powerupList[i].powerUpName;
            holder.powerupPrice.text = powerupList[i].powerupPrice.ToString();
            holder.powerupID = powerupList[i].powerupID;

            //buy
            holder.buyButton.GetComponent<buyPowerup>().itemID = powerupList[i].powerupID;

            itemHolderList.Add(powerHolder);

            if (powerupList[i].powerupBought == true)
            {
                holder.powerupSprite.sprite = Resources.Load<Sprite>("Sprite/"+ powerupList[i].boughtPower);
            }
            else
            {
                holder.powerupSprite.sprite = Resources.Load<Sprite>("Sprite/" + powerupList[i].unboughtPower);
            }
        }
    }

    public void updateSprite(int itemID)
    {
        for (int i = 0; i < itemHolderList.Count; i++)
        {
           dataHolder holder = itemHolderList[i].GetComponent<dataHolder>();
           if (holder.powerupID == itemID)
           {
               for (int j = 0; j < powerupList.Count; j++)
               {
                   if (powerupList[j].powerupID == itemID)
                   {
                       if (powerupList[j].powerupBought == true)
                       {

                           if (powerupList[j].powerupBought == true)
                           {
                               holder.powerupSprite.sprite = Resources.Load<Sprite>("Sprite/" + powerupList[i].boughtPower);
                           }
                           else
                           {
                               holder.powerupSprite.sprite = Resources.Load<Sprite>("Sprite/" + powerupList[i].unboughtPower);
                           }
                       }
                   }
               }
           }
        }
    }

    
}
