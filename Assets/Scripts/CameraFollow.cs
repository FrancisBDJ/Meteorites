using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Cached reference
    public Transform playerTransform;

    private Vector3 offset = new Vector3(0, 6.0f, -10.0f);
    

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
