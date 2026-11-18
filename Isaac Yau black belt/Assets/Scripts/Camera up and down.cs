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

    }

    // Update is called once per frame
    void Update()
    {
        // Get how much the mouse moved this frame, multiplied by sensitivity
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -85f, 85f);
        // Get how much the mouse moved this frame, multiplied by sensitivity

        // 2. Look LEFT and RIGHT (Rotates the entire player body on the Y axis)
        gameObject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
    }
}
