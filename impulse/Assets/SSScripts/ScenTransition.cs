
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenTransition : MonoBehaviour
{

    public Slider loadSlider;
    public GameObject loadPanel;
    public Text progresssss;
    public void loadScene(int sceneNumber)
    {
        PlayerPrefs.Save();
        StartCoroutine(loadAsync(sceneNumber));
    }

    IEnumerator loadAsync(int sceneNumber)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNumber);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadSlider.value = progress;
            progresssss.text = (Mathf.Round(progress * 1000)/10f + "%");
            Debug.Log(progress);
            loadPanel.SetActive(true);
            yield return null;
        }
        loadPanel.SetActive(false);
    }
}
