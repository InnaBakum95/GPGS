using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savesystemManager : MonoBehaviour {

    public static savesystemManager managerInstance;

    public int CollectedCoins;
    Coin coins;

	// Use this for initialization
	void Start () 
    {
        managerInstance = this;
        DontDestroyOnLoad(this.gameObject);
        coins = FindObjectOfType<Coin>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //CollectedCoins = coins.coin;
	}
}
