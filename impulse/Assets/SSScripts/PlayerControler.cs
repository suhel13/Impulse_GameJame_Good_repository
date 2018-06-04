using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Rigidbody rb;
    [Range(5f, 15f)] public float speed;
    Vector3 axis;
    public LightUpControler lightUpCon;
    public GameObject circle;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.z = Input.GetAxis("Vertical");
        if (axis.magnitude > 1)
        {
            axis.Normalize();
        }

        rb.velocity = axis * speed;

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(circle, transform.position, Quaternion.identity);
            lightUpCon.showLights();
        }

    }
}
