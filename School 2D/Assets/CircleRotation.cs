using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    [SerializeField] float degreesPerSec = 360f;
    bool isLeft = true;

    void Update()
    {
        float rotAmount = degreesPerSec * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;

        if (Input.GetMouseButtonDown(0))
        {
            isLeft = !isLeft;
        }

        if (isLeft)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));

        }
        else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot - rotAmount));

        }
    }
}
