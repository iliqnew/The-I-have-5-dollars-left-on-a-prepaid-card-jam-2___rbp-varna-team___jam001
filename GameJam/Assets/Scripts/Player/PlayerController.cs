using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private LayerMask JumpColidableLayerMast;
	private BoxCollider2D boxCollider2d;
	private Rigidbody2D rb;
	
	public float horizontalSpeed = 1f;
	public float jumpForce = 100f;
	public float groundedDistance = 0f;
	
	public int level = 1;
	public int health = 100;
	
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
		boxCollider2d = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, rb.velocity.y);
		rb.AddTorque(Input.GetAxis("Horizontal") * horizontalSpeed * -1, ForceMode2D.Force);
		
		RaycastHit2D grounded = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, groundedDistance, JumpColidableLayerMast);
		
		if (Input.GetAxis("Jump") > 0 && grounded.collider != null){
			rb.velocity = Vector2.up * jumpForce;
		}
	}
}
