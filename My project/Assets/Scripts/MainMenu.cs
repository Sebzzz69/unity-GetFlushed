using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene("MainGame");
        //GameObject.Find("SceneLoader").GetComponent<PreloadScene>().LoadScene("MainGame");
        GameObject.Find("SceneLoader").GetComponent<SceneLoader>().LoadSceneAsync("MainGame");
        GameObject.Find("SceneLoader").GetComponent<SceneLoader>().ActivateLoadedScene();

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
