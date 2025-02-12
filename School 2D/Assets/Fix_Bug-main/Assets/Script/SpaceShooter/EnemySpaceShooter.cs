using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShooter : MonoBehaviour
{
    public SpaceshipController SpaceShip;
    public int health;
    public float minFR, MaxFR;
    private float FireRate;
    private float storedFireRate;
    public float BulletSpeed;
    public GameObject BulletPrefab;

    public float moveSpeed;
    public float moveInterval;

    public Vector3 InitialPosition;

    // Start is called before the first frame update
    private void Start()
    {
        InitialPosition = transform.position;
        FireRate = Random.Range(minFR, MaxFR);
        storedFireRate = FireRate;
        //InvokeRepeating
        InvokeRepeating("MoveEnemy", 5, moveInterval);
    }

    // Update is called once per frame
    private void Update()
    {
        FireRate -= Time.deltaTime;
        if (FireRate <= 0)
        {
            SpawnBullet();
            FireRate = storedFireRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health--;
            if (health <= 0)
            {
                SpaceShip.score++;
                gameObject.SetActive(false);
            }
            BulletPool.Instance.ReturnBullet(collision.gameObject, true);
        }
    }

    public void SpawnBullet()
    {
        GameObject bullet = BulletPool.Instance.GetBullet(false);
        if (bullet == null) return;

        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = new Vector2(0f, -BulletSpeed);
    }

    public void MoveEnemy()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}