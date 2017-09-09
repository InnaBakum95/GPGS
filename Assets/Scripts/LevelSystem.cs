using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour {

    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;
   //  Xp collectedXp;
    public Slider slider;
   

    public void Start()
    {
       // collectedXp = FindObjectOfType<Xp>();
     
    }
    void Update()
    {

        slider.value = Xp.XpValue;
        currentExp = Xp.XpValue;
        if (currentExp >= toLevelUp[currentLevel])
        {

            for (int i = 0; i < toLevelUp.Length; i++)
            {
                slider.maxValue = toLevelUp[i];
                print("Hello");

            }

            Xp.XpValue = 0;
            currentLevel++;
        }
    }
   
}
