using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public GameObject car;
    public float speed;


    private void Update()
    {
        MoveObject();
    }
    public void MoveObject()
    {
        car.transform.position += transform.right * Time.deltaTime * speed;
    }
}
