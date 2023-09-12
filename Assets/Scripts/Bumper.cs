using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float reflectionForceMultiplier = 100.0f;

    private void OnCollisionEnter(Collision collision)
    {
        GameController.IncreaseScore(500);
    }
}
