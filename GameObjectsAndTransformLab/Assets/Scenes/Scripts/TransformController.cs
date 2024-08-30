using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    private void Update ()
    {
        var x = Mathf.PingPong(Time.time, 3);
        var p = new Vector3(0, x, 0);
        TransformController.position = p;

        TransformController.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
