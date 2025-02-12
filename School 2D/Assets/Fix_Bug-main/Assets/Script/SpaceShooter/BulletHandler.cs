using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] private bool isAlly;

    private void OnBecameInvisible()
    {
        BulletPool.Instance.ReturnBullet(gameObject, isAlly);
    }
}