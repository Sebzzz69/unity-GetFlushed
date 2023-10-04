using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private AsyncOperation asyncLoad;

    // Call this method to load a scene asynchronously
    public void LoadSceneAsync(string sceneName)
    {
        // Start loading the scene asynchronously
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Prevent the scene from being activated automatically upon loading
        asyncLoad.allowSceneActivation = false;
    }

    // Check the loading progress(0.0 to 1.0)
    public float GetLoadingProgress()
    {
        if (asyncLoad != null)
        {
            return asyncLoad.progress;
        }
        else
        {
            return 0.0f;
        }
    }

    // Activate the loaded scene when ready (call this when appropriate)
    public void ActivateLoadedScene()
    {
        if (asyncLoad != null)
        {
            asyncLoad.allowSceneActivation = true;
        }
    }
}
