using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private LayerMask JumpColidableLayerMast;
	
	
	public AudioSource hitAudio;
	public GameObject gameOver;
	private Rigidbody2D rb;
	private EdgeCollider2D hitCollider;
	public GameObject textureSprite;
	private SpriteRenderer texture;
	
	public float maxSpeed = 40f;
	public float horizontalSpeed = 1f;
	public float jumpForce = 100f;
	public float groundedDistance = 0f;
	
	public int level = 1;
	
	public int health = 5;
	public int enemyDamage = 1;
	public bool doubleAttack = false;
	public bool allAttack = false;
	public float particleSpeed = 1.0f;
	public float timer = 1.0f;
	
	private float hitInvincability;
	private float hitInvincabilityCooldown = 0f;
	
	public float hitFlickerTime = 0.1f;
	public int hitFlickerTimes = 10;
	private bool flicker = false;
	
	public GameObject skillRock;
	public float skillRockTimer = 2f;
	private float skillRockCooldown = 0f;
	
	public GameObject skillAcidBall;
	public float skillAcidBallTimer = 5f;
	private float skillAcidBallCooldown = 0f;
	
	public GameObject skillWind;
	public float skillWindTimer = 2f;
	private float skillWindCooldown = 0f;
	public float skillWindBacklash = 10f;
	
	public GameObject skillForceField;
	public AudioSource forceFieldBreakingAudio;
	private SpriteRenderer forceFielsTexture;
	public float skillForceFieldTimer = 2f;
	private float skillForceFieldCooldown = 0f;
	
	//=====================SAVE/LOAD Buttons Script=========================
	public void SavePlayer(){
		SaveSystem.SavePlayer(this);
	}
	 public void LoadPlayer(){
		PlayerData data = SaveSystem.LoadPlayer();
		
		level = data.level;
		health = data.health;
		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];
		transform.position = position;
	}
	//======================================================================
	
    void Start()
    {
		//boxCollider2d = GetComponent<BoxCollider2D>();
		
        rb = GetComponent<Rigidbody2D>();
		hitCollider = GetComponent<EdgeCollider2D>();
		texture = textureSprite.GetComponent<SpriteRenderer>();
		forceFielsTexture = skillForceField.GetComponent<SpriteRenderer>();
		hitInvincability = hitFlickerTime * hitFlickerTimes;
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		
		//gameOver = GameObject.FindGameObjectsWithTag("GameOver")[0];
    }

    void FixedUpdate()
    {
		//============================ Move
		if (Mathf.Abs(rb.angularVelocity) < maxSpeed){
			rb.AddTorque(Input.GetAxis("Horizontal") * horizontalSpeed * -1, ForceMode2D.Force);
		}
		
		//============================ Jump
		//RaycastHit2D grounded = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, groundedDistance, JumpColidableLayerMast);
		
		//if (Input.GetAxis("Jump") > 0 && grounded.collider != null){
		//	rb.velocity = Vector2.up * jumpForce;
		//}
		//============================ Cast Rock
		if (skillRockTimer > skillRockCooldown){
			skillRockCooldown += Time.deltaTime;
		}
		
		if (Input.GetAxis("Jump") > 0 && skillRockTimer < skillRockCooldown){
			CastRock(skillRock);
			skillRockCooldown = 0f;

			if (doubleAttack)
			{
				StartCoroutine(AttackDobbleRock(0.1f, skillRock));	
			}
			if (allAttack)
			{
				CastAcidBall(skillAcidBall);
				CastWind(skillWind);	
				skillForceField.SetActive(true);
			}
		}
		//============================ AcidBall Rock
		if (skillAcidBallTimer > skillAcidBallCooldown){
			skillAcidBallCooldown += Time.deltaTime;
		}
		
		if (Input.GetAxis("E") > 0 && skillAcidBallTimer < skillAcidBallCooldown){
			CastAcidBall(skillAcidBall);
			skillAcidBallCooldown = 0f;
			if (doubleAttack)
			{
				StartCoroutine(AttackDobbleAcidBall(0.1f, skillAcidBall));	
			}
			if (allAttack)
			{
				CastRock(skillRock);
				CastWind(skillWind);	
				skillForceField.SetActive(true);
			}
		}
		//============================ Cast Wind
		if (skillWindTimer > skillWindCooldown){
			skillWindCooldown += Time.deltaTime;
		}
		
		if (Input.GetAxis("F") > 0 && skillWindTimer < skillWindCooldown){
			CastWind(skillWind);
			skillWindCooldown = 0f;
			if (doubleAttack)
			{
				StartCoroutine(AttackDobbleWind(0.1f, skillWind));	
			}
			if (allAttack)
			{
				CastAcidBall(skillAcidBall);
				CastRock(skillRock);
				skillForceField.SetActive(true);	
			}
		}
		//============================ Cast ForceField
		if (skillForceFieldTimer > skillForceFieldCooldown){
			skillForceFieldCooldown += Time.deltaTime;
		}
		
		if (Input.GetAxis("C") > 0 && skillForceFieldTimer < skillForceFieldCooldown){
			skillForceField.SetActive(true);
			skillForceFieldCooldown = 0f;
			if (allAttack)
			{
				CastRock(skillRock);
				CastWind(skillWind);	
				CastAcidBall(skillAcidBall);
			}
		}
		
		//============================ Hit Invincability After Hit
		if (hitInvincabilityCooldown < hitInvincability){
			hitInvincabilityCooldown += Time.deltaTime;
			if (hitInvincabilityCooldown > hitInvincability){
				hitCollider.enabled = true;
			}
		}

		//============================ Hit Flicker
		if (flicker){
			if (skillForceField.active){
				skillForceFieldCooldown = 0f;
				StartCoroutine(FlickerForceField(forceFielsTexture, skillForceField, hitFlickerTime, hitFlickerTimes, false));
				forceFieldBreakingAudio.Play();
				flicker = false;
			}
			else{
				skillForceFieldCooldown = 0f;
				StartCoroutine(FlickerPlayer(texture, hitFlickerTime, hitFlickerTimes));
				hitAudio.Play();
				flicker = false;
			}
		}
	
		//============================DIE
		if(health <= 0)
		{
			
			gameOver.SetActive(true);
			Destroy(this.gameObject, timer);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyAttack")){
			if (!skillForceField.active){
				health -= enemyDamage;
			}
			flicker = true;
			hitInvincabilityCooldown = 0f;
			hitCollider.enabled = false;
		}
	}
	
	void CastRock(GameObject skillRock){
		
		GameObject clone  = Instantiate(skillRock);
			
		Vector3 newRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y , transform.eulerAngles.z);
		clone.transform.eulerAngles = newRotation;
		clone.transform.position = transform.position;
		
		clone.SetActive(true);
	}
	
	void CastAcidBall(GameObject skillAcidBall){
		GameObject clone  = Instantiate(skillAcidBall);
			
		Vector3 newRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		clone.transform.eulerAngles = newRotation;
		clone.transform.position = transform.position;
		
		clone.SetActive(true);
	}
	
	void CastWind(GameObject skillWind){
		
		GameObject clone  = Instantiate(skillWind);
			
		Vector3 newRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		clone.transform.eulerAngles = newRotation;
		clone.transform.position = transform.position;
		
		clone.SetActive(true);
		
		float ycomponent = Mathf.Sin((transform.eulerAngles.z - 180) * Mathf.PI / 180);
		float xcomponent = Mathf.Cos((transform.eulerAngles.z -180) * Mathf.PI / 180);
        rb.AddForce(new Vector2(xcomponent, ycomponent).normalized * skillWindBacklash);
	}
	IEnumerator AttackDobbleRock(float secondy, GameObject skillRock)
	{
		yield return new WaitForSeconds(secondy);
		CastRock(skillRock);
		yield return null;
	}
	IEnumerator AttackDobbleWind(float secondy, GameObject skillWind)
	{
		yield return new WaitForSeconds(secondy);
		CastWind(skillWind);
		yield return null;
	}
	IEnumerator AttackDobbleAcidBall(float secondy, GameObject skillAcidBall)
	{
		yield return new WaitForSeconds(secondy);
		CastAcidBall(skillAcidBall);
		yield return null;
	}
	IEnumerator FlickerForceField(SpriteRenderer texture, GameObject body, float hitFlickerTime, int hitFlickerTimes, bool end)
	{
		for (int i = 0; i < hitFlickerTimes * 2; i++){
			texture.enabled = !texture.enabled;
			yield return new WaitForSeconds(hitFlickerTime);
		}
		
		texture.enabled = true;
		body.SetActive(end);

		yield return null;
	}
	IEnumerator FlickerPlayer(SpriteRenderer texture, float hitFlickerTime, int hitFlickerTimes)
	{
		for (int i = 0; i < hitFlickerTimes * 2; i++){
			texture.enabled = !texture.enabled;
			yield return new WaitForSeconds(hitFlickerTime);
		}
		
		texture.enabled = true;

		yield return null;
	}
	public void PlayEnemieDieingSound(AudioSource audio){
        audio.Play();
    }
}
