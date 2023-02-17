using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTPS : MonoBehaviour
{
    float yaw;
    float pitch;

    public float mouseMoveSpeed = 2;
    public Transform playerTransform;

    
    private void Update()
    {
        yaw += Input.GetAxis("Mouse X") * mouseMoveSpeed;
        pitch -= Input.GetAxis("Mouse Y") * mouseMoveSpeed;

        transform.eulerAngles = new Vector3(pitch, yaw, 0);

        transform.position = playerTransform.position - transform.forward * 3; //3->distance
        transform.position = transform.position - transform.right;
        transform.position = transform.position + transform.up;
    }
}
