using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCameraBack() 
    {
        transform.Translate(Vector3.forward * -500f * Time.deltaTime);
    }

    private void OnCameraForward()
    {
        transform.Translate(Vector3.forward * 500f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, transform.position.z);
    }
}
