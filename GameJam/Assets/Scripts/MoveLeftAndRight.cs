using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndRight : MonoBehaviour
{
    public float moveLength = 10f;
	public float speed = 2f;
	
	float position_X;
	bool direction = true;
	
	void Start(){
		position_X = transform.position.x;
	}
	
	
    void FixedUpdate()
    {
		if (position_X + moveLength > transform.position.x && direction){
			transform.Translate(Vector3.right / speed);
		}
		else{
			direction = false;
			transform.Translate(Vector3.left / speed);
			
			if (position_X > transform.position.x){
				direction = true;
			}
		}
	}
}