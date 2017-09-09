using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achivements {
    private string name;
    private string description;
    private bool unlcoked;
    private int point;
    private int spriteIndex;

    private GameObject achivementRef;
    private List<Achivements> dependencies = new List<Achivements>();

    private string child;
    public Achivements(string name, string description, int point, int spriteIndex, GameObject achivementRef)
    {
        this.Name = name;
        this.Description = description;
        this.Unlcoked = false;
        this.Point = point;
        this.SpriteIndex = spriteIndex;
        this.achivementRef = achivementRef;
        LoadAchivement();
    }
    public void AddDependency(Achivements dependency)
    {
        dependencies.Add(dependency);
    }


    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    public bool Unlcoked
    {
        get
        {
            return unlcoked;
        }

        set
        {
            unlcoked = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int Point
    {
        get
        {
            return point;
        }

        set
        {
            point = value;
        }
    }

    public int SpriteIndex
    {
        get
        {
            return spriteIndex;
        }

        set
        {
            spriteIndex = value;
        }
    }

    public string Child
    {
        get
        {
            return child;
        }

        set
        {
            child = value;
        }
    }

    public bool EarnAchivement()
    {
        if (!Unlcoked && !dependencies.Exists(x=> x.unlcoked==false))
        {
            achivementRef.GetComponent<Image>().sprite = achivementManager.Instance.unlockedSprite;
            SaveAchivement(true);
            //Unlcoked = true;
            if (child!=null)
            {
                achivementManager.Instance.EarnAchivement(child);
            }
            return true;
        }
        return false;
    }
    public void SaveAchivement(bool value)
    {
        unlcoked = value;
        int tmpPoints = PlayerPrefs.GetInt("Point");

        PlayerPrefs.SetInt("Point", tmpPoints += point);
        PlayerPrefs.SetInt(name, value ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void LoadAchivement()
    {

        unlcoked = PlayerPrefs.GetInt(name) == 1 ? true : false;
        if (unlcoked)
        {
            achivementManager.Instance.textPoints.text = "Points : " + PlayerPrefs.GetInt("Point");
            achivementRef.GetComponent<Image>().sprite = achivementManager.Instance.unlockedSprite;
        }
    }
}
