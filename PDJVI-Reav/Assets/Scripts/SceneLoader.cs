using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviourSingletonPersistent<SceneLoader>
{
    //[SerializeField] Slider slider;
    bool isLoading = false;
    public int CurrentScene { get;private set; }
    public override void Awake()
    {
        base.Awake();
    }

    public void LoadLevel(int sceneIndex) => LoadLevel(SceneManager.GetSceneByBuildIndex(sceneIndex).name);
    public void LoadLevel(string sceneName)
    {
        if (isLoading) return;
        CurrentScene = SceneManager.GetSceneByName(sceneName).buildIndex;
        LoadAsync(sceneName);
    }
    public void LoadAdditiveScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadAdditiveScenes()
    {
        if (SceneManager.sceneCount > 1)
        {
            for (int i = 1; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).isSubScene)
                    SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
            }
        }
    }

    public void RestartLevel()
    {
        if (isLoading) return;
        isLoading = true;
        LoadAsync(SceneManager.GetActiveScene().name);
    }

    public void CloseGame()
    {
        Debug.Log("bye :D");
        Application.Quit();
    }

    //Shows the async loading process via the referenced slide, then load the scene
    void LoadAsync(string sceneName)
    {
        isLoading = true;
        Time.timeScale = 1;
        UnloadAdditiveScenes();
        SceneManager.LoadSceneAsync(sceneName);
    }
}
