using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol1 : MonoBehaviour
{
    
	public float speed = 5f;
	public GameObject mouse;

	float position_X;
    
	public bool direction = true;
    Damage myParent;
	
	void Start(){
        myParent = transform.parent.GetComponent<Damage>();
		position_X = transform.position.x + 1f;
		
        if (direction)
        {
            mouse.transform.localScale = new Vector2(mouse.transform.localScale.x * (-1), mouse.transform.localScale.y);
        }
        else
        {
            mouse.transform.localScale = new Vector2(mouse.transform.localScale.x, mouse.transform.localScale.y);
        }
		
		GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
	}
	
	
    void FixedUpdate()
    {
		if (position_X == transform.position.x){
			direction = !direction;
		}
		else if (position_X < transform.position.x){
			mouse.transform.localScale = new Vector2(Mathf.Abs(mouse.transform.localScale.y) * (-1), mouse.transform.localScale.y);
		}
		else{
			mouse.transform.localScale = new Vector2(Mathf.Abs(mouse.transform.localScale.y), mouse.transform.localScale.y);
		}
		
		position_X = transform.position.x;
		
		if (direction)
        {
			transform.Translate(Vector3.right * speed * myParent.SpeedModifier);
		}
		else
        {
			transform.Translate(Vector3.left * speed * myParent.SpeedModifier);
		}
	}
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        direction = !direction;
	}
}