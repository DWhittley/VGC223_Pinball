using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    [SerializeField]
    private GameObject LeftFlipper;
    [SerializeField]
    private GameObject RightFlipper;

    [SerializeField] float hitStrength = 80000f;
    [SerializeField] float dampening = 2000f;
    [SerializeField] HingeJoint hingeJointLeft;
    [SerializeField] HingeJoint hingeJointRight;
    private JointSpring jointSpringReleased = new();
    private JointSpring jointSpringPressed = new();
    private bool leftFlipperPressed, rightFlipperPressed;

    // Start is called before the first frame update
    void Start()
    {
        if (LeftFlipper != null && RightFlipper != null)
        {
            jointSpringPressed.spring = jointSpringReleased.spring = hitStrength;
            jointSpringPressed.damper = jointSpringReleased.damper = dampening;
            jointSpringPressed.targetPosition = hingeJointLeft.limits.max;
            jointSpringReleased.targetPosition = hingeJointLeft.limits.min;
        }
        else
        {
            Debug.LogError("LeftFlipper or RightFlipper not found.");
        }
    }

    private void OnLeftFlipper(InputValue value)
    {
        
        leftFlipperPressed = value.isPressed;
    }

    private void OnRightFlipper(InputValue value) 
    {
        
        rightFlipperPressed = value.isPressed;
    }

    // Update is called once per frame
    void Update()
    {
        if(leftFlipperPressed)
        {
            hingeJointLeft.spring = jointSpringPressed;
        }
        else
        {
            hingeJointLeft.spring = jointSpringReleased;
        }

        if (rightFlipperPressed)
        {
            
            hingeJointRight.spring = jointSpringPressed;
        }
        else
        {
            hingeJointRight.spring = jointSpringReleased;
        }
    }
}
