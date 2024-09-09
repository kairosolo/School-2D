using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    private void Start()
    {
        Circle.Instance.OnGameOver += Circle_OnGameOver;
    }

    private void Circle_OnGameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
}
