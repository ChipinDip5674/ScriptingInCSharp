using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinker : MonoBehaviour
{

    public float shrinkFactor = 0.9f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.localScale *= shrinkFactor;
    }


}
