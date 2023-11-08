using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] HandleScore playerOne;
    [SerializeField] HandleScore playerTwo;

    int playerOneScore;
    int playerTwoScore;

    private void Awake()
    {

    }

    private void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    private void Update()
    {
        playerOne.GetScore(playerOneScore);
        playerTwo.GetScore(playerTwoScore);

        if (playerOneScore >= 10 || playerTwoScore >= 10)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

     

}
