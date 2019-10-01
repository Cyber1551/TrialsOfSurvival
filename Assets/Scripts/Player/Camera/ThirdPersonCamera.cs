using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 10;
    [SerializeField] private Transform target;
    [SerializeField] private float dstFromTarget = 2;
    [SerializeField] private Vector2 pitchMinMax = new Vector2(-40, 85);
    [SerializeField] private float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVel;
    Vector3 currentRot;
    float yaw;
    float pitch;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        currentRot = Vector3.SmoothDamp(currentRot, new Vector3(pitch, yaw), ref rotationSmoothVel, rotationSmoothTime);
        transform.eulerAngles = currentRot;
        transform.position = target.position - transform.forward * dstFromTarget;
    }
}
