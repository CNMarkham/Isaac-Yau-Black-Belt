using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraupanddown : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        // Get how much the mouse moved this frame, multiplied by sensitivity
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 1. Look UP and DOWN (Rotates the camera on the X axis)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents flipping upside down

        transform.rotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
