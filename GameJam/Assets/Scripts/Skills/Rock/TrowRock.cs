using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrowRock : MonoBehaviour
{
	public GameObject player;
	private Rigidbody2D rb;
	public float force = 10f;
	public float time = 5f;
	public float randmoTorqueRange = 200f;
	public float particleSpeed = 1.0f;
	
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		
		float ycomponent = Mathf.Sin(player.transform.eulerAngles.z * Mathf.PI / 180);
		float xcomponent = Mathf.Cos(player.transform.eulerAngles.z * Mathf.PI / 180);
		
        rb.AddForce(new Vector2(xcomponent, ycomponent).normalized * force * particleSpeed);
		
		rb.AddTorque(Random.Range(randmoTorqueRange * -1, randmoTorqueRange), ForceMode2D.Force);
		
		Destroy(this.gameObject, time);
    }
}
