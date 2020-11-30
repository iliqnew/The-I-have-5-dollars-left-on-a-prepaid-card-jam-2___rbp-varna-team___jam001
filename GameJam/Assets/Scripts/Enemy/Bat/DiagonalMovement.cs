using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMovement : MonoBehaviour
{
    public float moveLength = 10f;
	public float speed = 2f;
	
	float position_X;
    float position_Y;
	bool direction = true;
    bool direction1 = true;
	Damage myParent;
	
	void Start(){
		position_X = transform.position.x;
        position_Y = transform.position.y;
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
        
        
        if (position_Y + moveLength > transform.position.y && direction){
			transform.Translate(Vector3.up * speed * myParent.SpeedModifier);
		}
		else{
			direction1 = false;
			transform.Translate(Vector3.down * speed * myParent.SpeedModifier);
			
			if (position_X > transform.position.x){
				direction1 = true;
			}
		}
	}
}
