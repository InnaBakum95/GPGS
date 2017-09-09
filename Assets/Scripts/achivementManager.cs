using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class achivementManager : MonoBehaviour {

    public GameObject achivementPrefab;
    public Sprite[] sprites;

    public GameObject visualAchivement;
    public Dictionary<string, Achivements> achivements = new Dictionary<string, Achivements>();

    public Sprite unlockedSprite;
    public Text textPoints;
    private int fadeTime=2;
    private static achivementManager instance;


    public static achivementManager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = GameObject.FindObjectOfType<achivementManager>();
            }
            return achivementManager.instance;
        }
    }

    // Use this for initialization
    void Start () {
        CreateAchivement("General","Press W","Press w to unlock this achivement",5,0);
        CreateAchivement("General","Press s", "Press s to unlock this achivement", 5, 0);
        CreateAchivement("General"," All KEys", "Press all keys to unlock this achivement", 10, 0, new string[] { "Press W", "Press s" });

        PlayerPrefs.DeleteAll();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            EarnAchivement("Press W");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Press S");
            EarnAchivement("Press s");
        }
    
	}
    public void EarnAchivement(string title)
    {
        if (achivements[title].EarnAchivement())
        {
            //Do Someting.
            GameObject achivemnt = (GameObject)Instantiate(visualAchivement);
            SetAchivementInfo("EarnCanvas", achivemnt, title);
            textPoints.text = "Points : " + PlayerPrefs.GetInt("Point");
            StartCoroutine(HideAchivement(achivemnt));
        }

    }
    public IEnumerator HideAchivement(GameObject achivement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achivement);
    }
    public void CreateAchivement(string parent, string title,string descripion, int point, int spriteIndex,string[] dependencies=null)
    {
        GameObject achivement = (GameObject)Instantiate(achivementPrefab);
        Achivements newAchivents = new Achivements(name, descripion, point, spriteIndex,achivement);

        achivements.Add(title, newAchivents);
        SetAchivementInfo(parent, achivement,title);
        if (dependencies!=null)
        {
            foreach (string achivementTitle in dependencies)
            {
                Achivements dependency = achivements[achivementTitle];
                dependency.Child = title;
                newAchivents.AddDependency(dependency);

                
            }
        }
    }
    public void SetAchivementInfo(string parent, GameObject achivement, string title)
    {
        achivement.transform.SetParent(GameObject.Find(parent).transform);
        //Make appear with scale size of 1,1,1
        achivement.transform.localScale = new Vector3(1, 1, 1);
        achivement.transform.GetChild(0).GetComponent<Text>().text = title;
        achivement.transform.GetChild(1).GetComponent<Text>().text = achivements[title].Description;
        achivement.transform.GetChild(2).GetComponent<Text>().text = achivements[title].Point.ToString();
        achivement.transform.GetChild(3).GetComponent<Image>().sprite = sprites[achivements[title].SpriteIndex];
    }
    //private IEnumerator FadeAchivement(GameObject achivement)
    //{
    //    CanvasGroup canvasGroup = achivement.GetComponent<CanvasGroup>();
    //    float rate = 1.0f / fadeTime;
    //    int startAlpha = 0;
    //    int endAlpha = 1;
    //}
}
