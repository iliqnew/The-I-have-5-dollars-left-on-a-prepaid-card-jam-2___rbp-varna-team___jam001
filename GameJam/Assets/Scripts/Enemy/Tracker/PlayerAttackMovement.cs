using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMovement : MonoBehaviour
{
    private GameObject target;
    public float m_Speed = 10f;
	public float startTime= 0.1f;
	bool start = false;
	
    void Start()
    {
		StartCoroutine(LateStart(startTime));
    }
	
	void FixedUpdate(){
		if (start){
			Vector3 diff = target.transform.position - transform.position;
			diff.Normalize();
	 
			float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
			
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, target.transform.position.y), m_Speed * Time.deltaTime);
		}
		
	}
 
    IEnumerator LateStart(float startTime)
    {
        yield return new WaitForSeconds(startTime);
        target = GameObject.FindGameObjectsWithTag("Player")[0];
		start = true;
    }
}
