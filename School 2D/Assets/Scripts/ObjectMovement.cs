using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform rotationTransform;
    [SerializeField] private float rotationSpeed;

    private Vector3 moveDirection;

    private void Update()
    {
        // Move the object based on the direction set by SetDirection
        transform.Translate(moveDirection * Time.deltaTime * speed);
        rotationTransform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

    public void SetDirection(SpawnDirection direction)
    {
        switch (direction)
        {
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