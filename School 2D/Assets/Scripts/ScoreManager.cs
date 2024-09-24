using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score;

    private void Start()
    {
        Circle.Instance.OnCoin += Circle_OnCoin;

        score = 0;
        scoreText.text = score.ToString();
    }

    private void Circle_OnCoin()
    {
        AddScore();
    }

    void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
