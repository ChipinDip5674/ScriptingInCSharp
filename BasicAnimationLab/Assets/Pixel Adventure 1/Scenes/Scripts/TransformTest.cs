using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    // Speed of movement
    public float moveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input from arrow keys and move the object accordingly
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveY = Input.GetAxis("Vertical") * moveSpeed;

        // Update position based on arrow key input
        transform.position = transform.position + new Vector3(moveX, moveY, 0);


    }
}
