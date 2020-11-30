using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPuddle : MonoBehaviour
{
	public GameObject splash;
	public float duration = 1f;
	
	void OnTriggerEnter2D(Collider2D col){
		
		if (col.gameObject.layer == LayerMask.NameToLayer("Player") || col.gameObject.layer == LayerMask.NameToLayer("EnemyAttack")){
			GameObject clone  = Instantiate(splash);
			clone.transform.position = col.gameObject.transform.position;
			clone.SetActive(true);
			Destroy(clone.gameObject, duration);
			}
	}
}