using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float zoom;
    public float speed = 5f;
    public float DestFov = 50f;


    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
      //  HandleZoom();
       
    }

    private void HandleZoom()
    {
        float zoomChangeAmount = 80f;
        if(Input.mouseScrollDelta.y > 0)
        {
            zoom -= zoomChangeAmount * Time.deltaTime;
            Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, DestFov, Time.deltaTime * speed);
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoom += zoomChangeAmount * Time.deltaTime;
            Camera.main.fieldOfView = Mathf.MoveTowards(DestFov, Camera.main.fieldOfView, Time.deltaTime * speed);
        }
    }
}
