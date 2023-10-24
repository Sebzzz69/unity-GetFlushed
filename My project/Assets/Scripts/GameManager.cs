using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] HandleScore playerOne;
    [SerializeField] HandleScore playerTwo;

    int playerOneScore;
    int playerTwoScore;

    private void Awake()
    {
        DontDestroyOnLoad(this);
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
            // DO SOMETHING IDKKK
        }
    }
}
