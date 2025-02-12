using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    public GameObject allyBulletPrefab;
    public GameObject enemyBulletPrefab;
    public int poolSize = 20;

    private ObjectPool<GameObject> allyBulletPool;
    private ObjectPool<GameObject> enemyBulletPool;

    private void Awake()
    {
        Instance = this;

        allyBulletPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(allyBulletPrefab),
            actionOnGet: bullet => bullet.SetActive(true),
            actionOnRelease: bullet => bullet.SetActive(false),
            actionOnDestroy: bullet => Destroy(bullet),
            collectionCheck: false,
            defaultCapacity: poolSize,
            maxSize: poolSize
        );

        enemyBulletPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(enemyBulletPrefab),
            actionOnGet: bullet => bullet.SetActive(true),
            actionOnRelease: bullet => bullet.SetActive(false),
            actionOnDestroy: bullet => Destroy(bullet),
            collectionCheck: false,
            defaultCapacity: poolSize,
            maxSize: poolSize
        );
    }

    public GameObject GetBullet(bool isAlly)
    {
        if (isAlly)
            return allyBulletPool.CountActive < poolSize ? allyBulletPool.Get() : null;
        else
            return enemyBulletPool.CountActive < poolSize ? enemyBulletPool.Get() : null;
    }

    public void ReturnBullet(GameObject bullet, bool isAlly)
    {
        if (isAlly)
            allyBulletPool.Release(bullet);
        else
            enemyBulletPool.Release(bullet);
    }
}