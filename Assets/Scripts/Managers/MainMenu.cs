using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject loading;
    [SerializeField] Slider slider;
    public void launchGameplayScene()
    {
        StartCoroutine(launchSceneAsync("GameplayScene"));
    }

    IEnumerator launchSceneAsync(string nameScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);

        loading.SetActive(true);

        while (!operation.isDone){

            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            yield return null;
        }
    }
}
