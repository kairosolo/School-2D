using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform rotationTransform;

    private Vector3 moveDirection;

    private void Update()
    {
        // Move the object based on the direction set by SetDirection
        transform.Translate(moveDirection * Time.deltaTime * speed);
    }

    private void Start()
    {
        // Set a random rotation for the rotationTransform
        rotationTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
    }

    public void SetDirection(SpawnDirection direction)
    {
        switch (direction)
        {
            case SpawnDirection.Top:
                // Move the object downward (screen top to bottom)
                moveDirection = -transform.up; // Equivalent to Vector3.down
                break;

            case SpawnDirection.Bottom:
                // Move the object upward (screen bottom to top)
                moveDirection = transform.up; // Equivalent to Vector3.up
                break;

            case SpawnDirection.Left:
                // Move the object to the right (screen left to right)
                moveDirection = -transform.right; // Equivalent to Vector3.left
                break;

            case SpawnDirection.Right:
                // Move the object to the left (screen right to left)
                moveDirection = transform.right; // Equivalent to Vector3.right
                break;

            default:
                moveDirection = Vector3.zero; // No movement by default
                break;
        }
    }
}