using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  
    private void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);

    }
}
