using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinusuidmovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveLength = 10f;
	public float speed = 10f;
	
	float position_X;
    float position_Y;
	bool direction = true;
    bool direction1 = true;
	float timer = 0f;
	Damage myParent;


	void Start(){
		position_X = transform.position.x;
        position_Y = transform.position.y;
		myParent = transform.parent.GetComponent<Damage>();
	}
	
	
    void FixedUpdate()
    {
		timer += Time.deltaTime;

		if (position_X + moveLength > transform.position.x && direction){
			transform.position = transform.position + new Vector3(Time.deltaTime * speed * myParent.SpeedModifier, 0, 0);
		}
		else{
			direction = false;
			transform.position = transform.position - new Vector3(Time.deltaTime * speed * myParent.SpeedModifier, 0, 0);
			
			if (position_X > transform.position.x){
				direction = true;
			}
		}
        
        transform.position = new Vector2 (transform.position.x, Mathf.Sin(timer)*2);
	}
}
