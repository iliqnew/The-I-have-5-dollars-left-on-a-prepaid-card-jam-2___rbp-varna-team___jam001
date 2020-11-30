using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowWind : MonoBehaviour
{
	float ycomponent;
	float xcomponent;
	
	public float force = 10f;
	public float time = 5f;
	public float scale = 1f;
	
    void Start()
    {
		Destroy(this.gameObject, time);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * force);
		transform.localScale += new Vector3(scale, scale, 0) * Time.deltaTime;
    }
}
