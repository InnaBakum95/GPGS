using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{

    public GameObject inventoryObject, dragonImg, spiralImg, doubleImage;
    public GameObject[] icons;

    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        foreach (Transform child in inventoryObject.transform)
        {
            if (child.gameObject.tag == other.gameObject.tag)
            {
                string textString = child.Find("Text").GetComponent<Text>().text;
                int count = System.Int32.Parse(textString) + 1;
                child.Find("Text").GetComponent<Text>().text = "" + count;
                return;
            }
        }

        GameObject i;
        if (other.gameObject.tag == "dragon")
        {
            i = Instantiate(icons[0], dragonImg.transform.position, dragonImg.transform.rotation);
            i.transform.SetParent(inventoryObject.transform);
        }
        if (other.gameObject.tag == "spiral")
        {
            i = Instantiate(icons[1], spiralImg.transform.position, spiralImg.transform.rotation);
            i.transform.SetParent(inventoryObject.transform);
        }
        if (other.gameObject.tag == "double")
        {
            i = Instantiate(icons[2], doubleImage.transform.position, doubleImage.transform.rotation);
            i.transform.SetParent(inventoryObject.transform);
        }
    }
}

