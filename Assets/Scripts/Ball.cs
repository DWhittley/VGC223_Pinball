using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 previousPosition;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        rb.AddForce(new Vector3(0,130,0), ForceMode.VelocityChange);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Vector2 speed = position - previousPosition;
        Vector2 rotation = Vector2.Perpendicular(speed);
        transform.Rotate(new Vector3(rotation.x, rotation.y, 0), -speed.magnitude * 40f, Space.World);
    }
}
