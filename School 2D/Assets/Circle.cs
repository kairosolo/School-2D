using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public event Action OnCoin;
    public event Action OnGameOver;
    public static Circle Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin coin))
        {
            //Add point
            OnCoin?.Invoke();
            Destroy(coin.gameObject);
        }
        else if (collision.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            //Game Over
            OnGameOver?.Invoke();
        }
      
    }
   
}
