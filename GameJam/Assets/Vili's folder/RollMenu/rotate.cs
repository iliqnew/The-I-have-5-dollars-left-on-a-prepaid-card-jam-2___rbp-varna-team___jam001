using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
	public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(Random.value * speed, Random.value * speed, Random.value * speed));
    }
}
