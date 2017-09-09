using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Xp : MonoBehaviour {

    public static int XpValue;
    public Text xp;
    
    public Slider XPslider;
    void Start()
    {
        
        // Set up the reference.
        xp = GetComponent<Text>();
        

        
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
      
        
       xp.text = "XP: " + XpValue;
       XPslider.value = XpValue;

    }
   
}
