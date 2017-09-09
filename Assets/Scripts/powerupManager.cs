using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupManager : MonoBehaviour {

	

    public void OnMouseDown()
    {
        if (usePowerUps.powerup.BtnCounter == 1)
        {
            Debug.Log("Dragon Power");
            usePowerUps.powerup.BtnCounter = 0;
        }

        if (usePowerUps.powerup.BtnCounter == 2)
        {
            Debug.Log("Spiral Power");
            usePowerUps.powerup.BtnCounter = 0;
        }

        if (usePowerUps.powerup.BtnCounter == 3)
        {
            Debug.Log("Double Cannon Power");
            usePowerUps.powerup.BtnCounter = 0;
        }
    }
}
