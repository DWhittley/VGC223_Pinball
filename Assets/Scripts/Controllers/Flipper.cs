using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    [SerializeField] float hitStrength = 80000f;
    [SerializeField] float dampening = 250f;
    [SerializeField] HingeJoint hingeJointLeft;
    [SerializeField] HingeJoint hingeJointRight;
    private JointSpring jointSpringReleased = new();
    private JointSpring jointSpringPressed = new();
    private bool leftFlipperPressed, rightFlipperPressed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hinge Joint Left: " + hingeJointLeft);
        Debug.Log("Hinge Joint Right: " + hingeJointRight);
        jointSpringPressed.spring = jointSpringReleased.spring = hitStrength;
        jointSpringPressed.damper = jointSpringReleased.damper = dampening;
        jointSpringPressed.targetPosition = hingeJointLeft.limits.max;
        jointSpringReleased.targetPosition = hingeJointLeft.limits.min;
    }

    private void OnLeftFlipper(InputValue value)
    {
        Debug.Log("left flipper pressed");
        leftFlipperPressed = value.isPressed;
    }

    private void OnRightFlipper(InputValue value) 
    {
        Debug.Log("right flipper pressed");
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
