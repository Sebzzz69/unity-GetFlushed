using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleScore : MonoBehaviour
{
    [SerializeField] TMP_Text textScore;

    int score;

    public void UpdateScore()
    {
        textScore.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score++;
            UpdateScore();
        }
    }
}
