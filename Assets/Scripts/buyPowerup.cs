using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyPowerup : MonoBehaviour {

    public int itemID;

    public void buyItem()
    {
        if (itemID == 0)
        {
            Debug.Log("Id error");
            return;
        }

        for (int i = 0; i < shopManager.instance.powerupList.Count; i++)
        {
            if (shopManager.instance.powerupList[i].powerupID == itemID && !shopManager.instance.powerupList[i].powerupBought &&  gameManager.manager.checkMoney(shopManager.instance.powerupList[i].powerupPrice))
            {
                shopManager.instance.powerupList[i].powerupBought = true;
                gameManager.manager.decreaseMoney(shopManager.instance.powerupList[i].powerupPrice);
            }
            else if (shopManager.instance.powerupList[i].powerupID == itemID && !shopManager.instance.powerupList[i].powerupBought &&  !gameManager.manager.checkMoney(shopManager.instance.powerupList[i].powerupPrice))
            {
                Debug.Log("You are Poor");
            }
            else if (shopManager.instance.powerupList[i].powerupID == itemID && shopManager.instance.powerupList[i].powerupBought)
            {
                
            }
        }

        shopManager.instance.updateSprite(itemID);
    }

}
