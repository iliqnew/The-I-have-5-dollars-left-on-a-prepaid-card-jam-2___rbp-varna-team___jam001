using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AcidBall : MonoBehaviour
{
	public GameObject explosion;
	public float force;
	public float particle_speed;
	public float projectile_life;
	public float particleSpeed = 1.0f;
	
    void Start()
    {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		Destroy(this.gameObject, projectile_life);
    }
	
    void FixedUpdate()
    {
		transform.Translate(Vector3.right * force * particleSpeed);
    }
	
	void OnCollisionEnter2D (Collision2D col) 
    {
		GameObject clone  = Instantiate(explosion);
			
		clone.transform.position = new Vector3 (col.GetContact(0).point.x, col.GetContact(0).point.y, 0);
		clone.SetActive(true);
		Destroy(clone.gameObject, 1);
		Destroy(this.gameObject);
    }
}