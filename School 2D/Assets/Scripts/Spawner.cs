using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private Transform coin;
    [SerializeField] private Transform obstacle;

    [SerializeField] private float yMin, yMax;

    private float currentSpawnTime;
    private float xMin, xMax;

    private void Start()
    {
        // Get the camera's boundaries in world coordinates
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.z));

        // Assign the boundaries
        xMin = bottomLeft.x;
        xMax = topRight.x;

        StartCoroutine(SpawnInteractables());
    }

    private IEnumerator SpawnInteractables()
    {
        yield return new WaitForSeconds(spawnTime);

        int obstacleNum = Random.Range(1, 3);
        for (int i = 0; i < obstacleNum; i++)
        {
            SpawnBehavior obstacleBehavior = GetRandomEdgePosition();
            ObjectMovement obstacleMovement = Instantiate(obstacle, obstacleBehavior.spawnPosition, Quaternion.identity).GetComponent<ObjectMovement>();
            if (obstacleMovement != null) obstacleMovement.SetDirection(obstacleBehavior.spawnDirection);
        }

        float coinSpawnDelay = 1f;
        yield return new WaitForSeconds(coinSpawnDelay);
        SpawnBehavior coinBehavior = GetRandomEdgePosition();
        ObjectMovement coinMovement = Instantiate(coin, coinBehavior.spawnPosition, Quaternion.identity).GetComponent<ObjectMovement>();
        if (coinMovement != null) coinMovement.SetDirection(coinBehavior.spawnDirection);
        StartCoroutine(SpawnInteractables());
    }

    // Function to get random edge position and direction
    private SpawnBehavior GetRandomEdgePosition()
    {
        // Create a new SpawnBehavior object to hold the result
        SpawnBehavior spawnBehavior = new SpawnBehavior();

        // Randomly pick between the left and right edges
        int edge = Random.Range(0, 2);

        switch (edge)
        {
            case 0: // Left edge
                spawnBehavior.spawnDirection = SpawnDirection.Right;  // Move right from the left edge
                spawnBehavior.spawnPosition = new Vector3(xMin - 1, Random.Range(yMin, yMax), transform.position.z);
                break;

            case 1: // Right edge
                spawnBehavior.spawnDirection = SpawnDirection.Left;  // Move left from the right edge
                spawnBehavior.spawnPosition = new Vector3(xMax + 1, Random.Range(yMin, yMax), transform.position.z);
                break;
        }

        return spawnBehavior; // Return the spawn direction and position
    }
}

// Enum for the direction
public enum SpawnDirection
{
    Left,
    Right
}

// Class to store spawn behavior
public class SpawnBehavior
{
    public SpawnDirection spawnDirection;
    public Vector3 spawnPosition;
}