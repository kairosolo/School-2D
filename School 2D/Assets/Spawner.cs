using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private Transform coin;
    [SerializeField] private Transform obstacle;
    private float currentSpawnTime;
    private float xMin, xMax, yMin, yMax;
    private SpawnDirection direction;

    private void Start()
    {
        // Get the camera's boundaries in world coordinates
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.z));

        // Assign the boundaries
        xMin = bottomLeft.x;
        xMax = topRight.x;
        yMin = bottomLeft.y;
        yMax = topRight.y;
    }

    private void Update()
    {
        currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime < 0)
        {
            currentSpawnTime = spawnTime;

            Vector3 spawnPositionObstacle = GetRandomEdgePosition();
            Vector3 spawnPositionCoin = GetRandomEdgePosition();

            // Instantiate the obstacle and coin at random edge positions
            Instantiate(obstacle, spawnPositionObstacle, Quaternion.identity).TryGetComponent(out ObjectMovement obstacleMovement);
            Instantiate(coin, spawnPositionCoin, Quaternion.identity).TryGetComponent(out ObjectMovement coinMovement);
            obstacleMovement.SetDirection(direction);
            coinMovement.SetDirection(direction);
        }
    }

    // Function to get random edge position
    private Vector3 GetRandomEdgePosition()
    {
        // Randomly pick one of the four edges
        int edge = Random.Range(0, 4);

        switch (edge)
        {
            case 0: // Left edge
                direction = SpawnDirection.Left;
                return new Vector3(xMin, Random.Range(yMin, yMax), transform.position.z);

            case 1: // Right edge
                direction = SpawnDirection.Right;

                return new Vector3(xMax, Random.Range(yMin, yMax), transform.position.z);

            case 2: // Top edge
                direction = SpawnDirection.Top;

                return new Vector3(Random.Range(xMin, xMax), yMax, transform.position.z);

            case 3: // Bottom edge
                direction = SpawnDirection.Bottom;

                return new Vector3(Random.Range(xMin, xMax), yMin, transform.position.z);

            default:
                return Vector3.zero; // Fallback, shouldn't happen
        }
    }
}

public enum SpawnDirection
{
    Top,
    Bottom,
    Left,
    Right
}