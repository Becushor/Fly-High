using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform targetFollow;

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(targetFollow.position.y, 0f, 100f),
            transform.position.z);
    }
}
