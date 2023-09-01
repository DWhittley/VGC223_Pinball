using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 previousPosition;


    // Start is called before the first frame update
    void Start()
    {
        
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
