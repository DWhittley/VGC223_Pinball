using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float reflectionForceMultiplier = 100.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ball hit bumper");

        Rigidbody ballRigidbody = collision.collider.GetComponent<Rigidbody>();

        if (ballRigidbody != null)
        {
            // Calculate the reflection vector based on the incoming velocity
            Vector3 incomingVelocity = ballRigidbody.velocity;
            Vector3 normal = (collision.contacts[0].point - transform.position).normalized;
            Vector3 reflection = Vector3.Reflect(incomingVelocity, normal).normalized;

            // Apply the reflection as a force with a multiplier
            ballRigidbody.AddForce(reflection * reflectionForceMultiplier, ForceMode.Impulse);
        }
    }
}
