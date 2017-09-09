using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    public Text coinText;

    [SerializeField]
    private int gold;

    public static gameManager manager;

    // Use this for initialization

    void Start () 
    {
        gold += savesystemManager.managerInstance.CollectedCoins;
        updateMoneyUI();
        if (manager == null && manager != this)
        {
            manager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    public void addMoney(int amount)
    {

        gold += amount;
        updateMoneyUI();
    }

    public void decreaseMoney(int amount)
    {
        gold -= amount;
        updateMoneyUI();
    }

    public bool checkMoney(int money)
    {
        if (money <= gold)
        {
            return true;
        }
        return false;
    }

    void updateMoneyUI()
    {
        coinText.text = "" + gold.ToString("D"); 
    }

    public int getgoldInfo()
    {
        return gold;
    }

    public void setgoldInfo(int amount)
    {
        gold = amount;
        updateMoneyUI();
    }
}
