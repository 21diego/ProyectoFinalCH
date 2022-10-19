using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void launchGameplayScene()
    {
        StartCoroutine(launchSceneAsync("GameplayScene"));
    }

    IEnumerator launchSceneAsync(string nameScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);

        while (!operation.isDone){
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}
