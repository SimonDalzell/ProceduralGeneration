using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveCamera : MonoBehaviour
{
    void Update()
    {
       Vector3 v = GetInputs();
       Vector3 newPos = transform.position;
       transform.Translate(v);
       
    }

   
    private Vector3 GetInputs()
    {
        Vector3 camVelocity = new Vector3();       

        if (Input.GetKey(KeyCode.W))
        {           
           camVelocity += new Vector3(0,0,500);
        }
        if (Input.GetKey(KeyCode.S))
        {
            camVelocity += new Vector3(0,0,-500);
        }
        if (Input.GetKey(KeyCode.A))
        {
            camVelocity += new Vector3(-500,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            camVelocity += new Vector3(500,0,0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            camVelocity += new Vector3(0,-500,0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            camVelocity += new Vector3(0,500,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {            
            transform.Rotate(Vector3.up, 20.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {            
           transform.Rotate(Vector3.down, 20.0f * Time.deltaTime);
        }
       return camVelocity;
        
}
}
