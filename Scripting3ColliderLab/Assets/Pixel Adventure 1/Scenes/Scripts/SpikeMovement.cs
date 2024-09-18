using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
   
   
    // Start is called before the first frame update
    void Start()
    {


        transform.position = new Vector3(-2, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {


        var x = Mathf.PingPong(Time.time * 15, 3); transform.position = new Vector3(x, 0, 0);
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, .01f);
    }
}
