using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private float lightValue;
    private new Light light;
    [SerializeField] AudioSource soundCircle;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightValue > 0)
        {
            lightValue -= Time.deltaTime * 2000;
            if (lightValue > 10000)
            {
                light.intensity = (12000 - lightValue) * 5;
            }
            else
            {
                light.intensity = lightValue;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        soundCircle.Play();
        GameController.IncreaseScore(300);
        lightValue = 12000;

    }
}
