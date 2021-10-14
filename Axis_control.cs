using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis_control : MonoBehaviour
{
    GameObject target;
    void Start()
    {
        target = GameObject.Find("Broly");
    }

    void Update()
    {
        Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
        transform.LookAt(targetPosition);
    }
}
