using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public float Health = 10f;
	public float hitFlickerTime = 0.1f;
	public int hitFlickerTimes = 10;
	public SpriteRenderer texture;
	private Collider collider;
	private bool colliding = false;
	private GameObject projectile;
	public AudioSource deathAudio;
	public AudioSource hitAudio;
	public GameObject player;
    
    Damage myParent;
    
    void Start()
    {
        myParent = transform.parent.GetComponent<Damage>();
		collider = transform.parent.GetComponent<Collider>();
        Health *= myParent.healthMultiplier;
    }
    
    void Update()
    {
		if (projectile == null){
			colliding = false;
		}
		
        if( Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
	
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == LayerMask.NameToLayer("Projectile")){
			colliding = true;
			StartCoroutine(FlickerEnemie(texture, hitFlickerTime, hitFlickerTimes));
			projectile = collision.gameObject;
        }
    }
	
	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.layer == LayerMask.NameToLayer("Projectile")){
			colliding = false;
        }
	}
	
	IEnumerator FlickerEnemie(SpriteRenderer texture, float hitFlickerTime, int hitFlickerTimes)
	{
		while (colliding){
			Health -= myParent.damageTake;
			if (Health > 0){
				hitAudio.Play();
			}
			else{
				player = GameObject.FindGameObjectsWithTag("Player")[0];
				player.GetComponent<PlayerController>().PlayEnemieDieingSound(deathAudio);
			}
			
			for (int i = 0; i < hitFlickerTimes * 2; i++){
				texture.enabled = !texture.enabled;
				yield return new WaitForSeconds(hitFlickerTime);
			}
		}
		texture.enabled = true;

		yield return null;
	}
}
