using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attached to the MainCamera GameObject
/// Follows the player specified in the public Transform
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    private void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
