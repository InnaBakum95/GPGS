using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class usePowerUps : MonoBehaviour
{
    public static usePowerUps powerup;
    public int BtnCounter;

    void Start()
    {
        if (powerup == null)
        {
            powerup = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {

    }

    //public void OnMouseOver()
    //{
    //    Debug.Log("mouse over me");
    //    if (powerSelected == true)
    //    {
    //        Debug.Log("Selected");

    //        if (Input.GetMouseButtonDown(0))
    //        {

    //            Debug.Log("Power");

    //            if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) > 1)
    //            {
    //                int tcount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
    //                this.transform.Find("Text").GetComponent<Text>().text = "" + tcount;
    //            }
    //            else
    //            {
    //                Destroy(this.gameObject);
    //            }

    //            powerSelected = false;
    //        }
    //    }
    //}

    public void DragonPower()
    {
        BtnCounter = 1;
    }

    public void SpiralPower()
    {
        BtnCounter = 2;
    }

    public void DoubleCannon()
    {
        BtnCounter = 3;
    }
    
}