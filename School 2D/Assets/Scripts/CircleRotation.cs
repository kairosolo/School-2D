using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    [SerializeField] private float degreesPerSec = 360f;
    private bool isLeft = false;

    private void Update()
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