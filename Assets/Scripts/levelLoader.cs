using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;

    public void Loadscene(int levelNum)
    {
        StartCoroutine(levelLoadSync(levelNum));
    }

    IEnumerator levelLoadSync(int level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }
}
