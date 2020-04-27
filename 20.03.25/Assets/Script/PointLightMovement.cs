using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightMovement : MonoBehaviour
{
   
    float moveDelta = 38.0f; //Movable max value
    float moveSpeed = 1.5f; //Velocity
    Vector3 pos; //Position
   
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        v.y += moveDelta * Mathf.Sin(Time.time*moveSpeed);
        
        transform.position = v;
        
    }
}
