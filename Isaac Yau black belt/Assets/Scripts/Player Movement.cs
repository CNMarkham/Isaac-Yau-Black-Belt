using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framew
    void Update()
    {
        if (Input.GetKey("W"))
        {
            transform.translate(vector3 * speed * Time.deltatime);
        }
    }
}
