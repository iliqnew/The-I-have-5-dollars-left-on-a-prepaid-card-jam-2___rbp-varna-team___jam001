using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
	public float rotationSpeed = 5f;

    void FixedUpdate()
    {
		transform.Rotate(0, 0, rotationSpeed);
    }
}
