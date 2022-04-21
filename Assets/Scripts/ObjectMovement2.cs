using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement2 : MonoBehaviour
{
    public float min = 5f;
    public float max = -5f;
    
    // Use this for initialization
    void Start()
    {
       
        min = transform.position.z;
        max = transform.position.z + 10;

    }
   
    // Update is called once per frame
    void Update()
    {
       
        transform.position =new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time*4,max-min)+min);
       
    }
}
