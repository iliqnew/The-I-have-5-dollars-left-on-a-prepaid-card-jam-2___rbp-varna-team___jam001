using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
	public GameObject mouse;
	public GameObject enemyEmpty;
	public float spawnInterval = 2f;
	private float timer = 0f;
	public GameObject[] enemies;
	private bool done = false;
	private string str;
	
    void FixedUpdate()
    {
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies.Length == 0){
			Destroy(this.gameObject);
		}
		
		timer += Time.deltaTime;
		
		if (timer > spawnInterval){
			GameObject clone  = Instantiate(mouse);
			clone.transform.position = transform.position;
			clone.transform.SetParent(enemyEmpty.transform);
			clone.SetActive(true);
			timer = 0f;
		}
        
    }
}
