using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    Vector3 End_pos;
    Vector3 Start_pos;
    public float middle;




    void Start()
    {
        Start_pos = transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        End_pos = transform.position + new Vector3(1,0,0);
        middle += 0.0001f;
        transform.position = Vector3.Lerp(Start_pos, End_pos, middle);
    }
}
