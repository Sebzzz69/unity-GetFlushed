using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        //GameObject.Find("SceneLoader").GetComponent<PreloadScene>().LoadScene("MainGame");


    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
