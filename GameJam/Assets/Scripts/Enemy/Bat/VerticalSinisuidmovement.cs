using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSinisuidmovement : MonoBehaviour
{
    public float moveLength = 10f;
	public float speed = 10f;
	
	float timer = 0;

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
		timer += Time.deltaTime;

		if (position_Y + moveLength > transform.position.y && direction){
			transform.position = transform.position + new Vector3(0, Time.deltaTime * speed * myParent.SpeedModifier, 0);
		}
		else{
			direction = false;
			transform.position = transform.position - new Vector3(0, Time.deltaTime * speed * myParent.SpeedModifier, 0);
			
			if (position_Y > transform.position.y){
				direction = true;
			}
		}
        
        transform.position = new Vector2 (position_X + Mathf.Sin(timer) * 2, transform.position.y);
	}
}
