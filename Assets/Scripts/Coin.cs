using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    public static int coin;      // The player's score.
    public Text Cointext;                      // Reference to the Text component.
    //bool playerHasplayedBefore = false;
   
   
   
    void Awake()
    {
        // Set up the reference.
        Cointext = GetComponent<Text>();
        //coin = 0;
       
     

    }
    private void Start()
    {
        //coin=PlayerPrefs.GetInt("coins");
    }
   


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        //Cointext.text = "Coin: " + coin;
        //PlayerPrefs.SetInt("coins", coin);
        
    }
    //void saveall()
    //{
    //    PlayerPrefs.SetInt("coins", coin);
    //    //playerHasplayedBefore = true;
    //    //PlayerPrefs.SetString("playerHasplayedBefore", "yes");
    //}
    //void loadall()
    //{
        
    //}

}
