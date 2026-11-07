using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
    public int speedBack = 5;
    public int jumpCounter = 1;
    public Rigidbody rb;
    public float mouseSensitivity = 100f;
    public Transform playerBody; // Assign your Player capsule/object here

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per framew
    void Update()
    {
        Vector3 direction = transform.forward;
        Vector3 directionRight = transform.right;

        if (Input.GetKey("w"))
        {
            Vector3 move = direction * speed;
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }
        if (Input.GetKey("s"))
        {
            Vector3 move = direction * -speedBack; // Negative forward goes backward
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }
        if (Input.GetKey("d"))
        {
            Vector3 move = directionRight * speed; // Use directionRight for both X and Z
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }
        if (Input.GetKey("a"))
        {
            Vector3 move = directionRight * -speed; // Negative right goes left
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }
        if (Input.GetKeyDown("space"))
        {
            //transform.Translate(Vector3.up * speed * Time.deltaTime);
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
            rb.velocity += new Vector3(0,1,0);
            jumpCounter -= 1;
        }

        // Get how much the mouse moved this frame, multiplied by sensitivity
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // 2. Look LEFT and RIGHT (Rotates the entire player body on the Y axis)
        gameObject.transform.Rotate(Vector3.up * mouseX);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall")&& (Input.GetKey("Space")&& (Input.GetKey("d"))))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            jumpCounter += 1;
        }
    }
}
