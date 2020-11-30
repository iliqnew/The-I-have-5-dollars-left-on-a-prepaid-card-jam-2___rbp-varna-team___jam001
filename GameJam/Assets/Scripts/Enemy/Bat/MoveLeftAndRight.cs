using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndRight : MonoBehaviour
{
    public float moveLength = 10f;
	public float speed = 2f;
	
	float position_X;
	bool direction = true;
	Damage myParent;
	
	void Start(){
		position_X = transform.position.x;
		myParent = transform.parent.GetComponent<Damage>();
	}
	
	
    void FixedUpdate()
    {
		if (position_X + moveLength > transform.position.x && direction){
			transform.Translate(Vector3.right * speed * myParent.SpeedModifier);
		}
		else{
			direction = false;
			transform.Translate(Vector3.left * speed * myParent.SpeedModifier);
			
			if (position_X > transform.position.x){
				direction = true;
			}
		}
	}
}