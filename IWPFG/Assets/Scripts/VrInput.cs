using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class VrInput : MonoBehaviour
{
    [Header("Behaviour Options")]

    [SerializeField]
    private float speed = 1.0f;


    [SerializeField]
    private XRNode controllerNode = XRNode.LeftHand;

    [SerializeField]
    private bool checkForGroundOnJump = true;


    private InputDevice controller;

    private List<InputDevice> devices = new List<InputDevice>();

    public Transform cam;

    void Start()
    {
        

        GetDevice();
    }

    private void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(controllerNode, devices);
        controller = devices.FirstOrDefault();
    }

    void Update()
    {
        if (controller == null)
        {
            GetDevice();
        }

        UpdateMovement();
    }

    private void UpdateMovement()
    {
        Vector2 primary2dValue;

        InputFeatureUsage<Vector2> primary2DVector = CommonUsages.primary2DAxis;

        if (controller.TryGetFeatureValue(primary2DVector, out primary2dValue) && primary2dValue != Vector2.zero)
        {
            Debug.Log("primary2DAxisClick is pressed " + primary2dValue);

            var xAxis = primary2dValue.x * speed * Time.deltaTime;
            var zAxis = primary2dValue.y * speed * Time.deltaTime;

            Vector3 right = transform.TransformDirection(Vector3.right);
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            cam.transform.position += right * xAxis;
            cam.transform.position += forward * zAxis;
        }
    }

}
