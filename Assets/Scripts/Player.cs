using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform bodyTransform;
    public Transform cameraTransform;
    public float speed;
    public float yawRotationSpeed;
    public float pitchRotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        var directionIntent = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            directionIntent += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            directionIntent += Vector3.back;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            directionIntent += Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            directionIntent += Vector3.right;
        }

        var normalizedDirection = directionIntent.normalized;

        bodyTransform.position += bodyTransform.rotation * normalizedDirection * (Time.deltaTime * speed);

        var mouseXDelta = Input.GetAxis("Mouse X");

        bodyTransform.Rotate(Vector3.up, Time.deltaTime * yawRotationSpeed * mouseXDelta);

        var mouseYDelta = Input.GetAxis("Mouse Y");

        cameraTransform.Rotate(Vector3.right, -Time.deltaTime * pitchRotationSpeed * mouseYDelta);
        
        var rotation = cameraTransform.localRotation;

        var rotationX = rotation.eulerAngles.x;

        rotationX += -Time.deltaTime * pitchRotationSpeed * mouseYDelta;
        

        var unClampedRotationX = rotationX;

        if (unClampedRotationX >= 180)
        {
            unClampedRotationX -= 360;
        }

        var clampedRotationX = Mathf.Clamp(unClampedRotationX, -60, 60);

        cameraTransform.localRotation =
            Quaternion.Euler(new Vector3(
                clampedRotationX,
                rotation.eulerAngles.y,
                rotation.eulerAngles.z
            ));
    }
}