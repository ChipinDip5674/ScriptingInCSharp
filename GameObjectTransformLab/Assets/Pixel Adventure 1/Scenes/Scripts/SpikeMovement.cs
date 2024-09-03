using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-2, 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, -.001f, 0);
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, .1f);
    }
}
