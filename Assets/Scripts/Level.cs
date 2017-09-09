using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

    
    public Text levelup;
    LevelSystem upgradelevel;
	void Awake ()
    {
        levelup = GetComponent<Text>();
    }
     void Start()
    {
        upgradelevel = FindObjectOfType<LevelSystem>();
    }

    // Update is called once per frame
    void Update ()
    {
        levelup.text = "Level: " + upgradelevel.currentLevel.ToString();
        
    }
   
}
