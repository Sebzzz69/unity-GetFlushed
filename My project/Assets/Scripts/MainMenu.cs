using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Awake()
    {
       
    }

    public void StartGame()
    {
         GameObject.Find("SceneLoader").GetComponent<SceneLoader>().LoadSceneAsync("MainLevel");
         GameObject.Find("SceneLoader").GetComponent<SceneLoader>().ActivateLoadedScene();
    }

    public void CreditScreen()
    {

        GameObject.Find("Canvas").transform.Find("MainMenuScreen").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("CreditScreen").gameObject.SetActive(true);
    }

    public void BackMenuButton()
    {
        GameObject.Find("Canvas").transform.Find("CreditScreen").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("MainMenuScreen").gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
