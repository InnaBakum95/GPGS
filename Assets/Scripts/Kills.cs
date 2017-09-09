using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Kills : MonoBehaviour {

    public static int kills;
    public Text killText;
    public GameObject GameOverScreen;

	// Use this for initialization
	void Awake () {

        killText = GetComponent<Text>();
        kills = 0;
	}
	
	// Update is called once per frame
	void Update () {
        killText.text = "Kills: " + kills;
        
	}
}
