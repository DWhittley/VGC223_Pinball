using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioSource soundLostBall;
    [SerializeField] AudioSource soundBumper;
    [SerializeField] AudioSource soundSpring;
    Vector2 previousPosition;
    private Rigidbody rb;
    public float bounceForce = 2.0f;
    private Vector3 startPosition = new Vector3(26.7999992f, 20.7900009f, -0.8899999f);


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        soundSpring.Play();
        rb.AddForce(new Vector3(0,130,0), ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bumper"))
        {
            Debug.Log("ball hit bumper");
            soundBumper.Play();
            BumperBounce(collision.contacts[0].normal);
        }
    }

    public void BumperBounce(Vector3 normal)
    {
        //rb.velocity = Vector3.Reflect(rb.velocity, normal) * bounceForce;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Vector2 speed = position - previousPosition;
        Vector2 rotation = Vector2.Perpendicular(speed);
        transform.Rotate(new Vector3(rotation.x, rotation.y, 0), -speed.magnitude * 40f, Space.World);

        if(transform.position.y < 2.0f)
        {
            soundLostBall.Play();
            transform.position = startPosition;
        }
    }
}
