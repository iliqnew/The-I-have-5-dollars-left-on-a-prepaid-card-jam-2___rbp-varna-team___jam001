using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScene : MonoBehaviour
{
	public GameObject warning;
	public GameObject indexes;
	public AudioSource audio;
	public GameObject[] enemies;
	bool levelComplete = false;
	BoxCollider2D collider;
	
	void Start(){
		indexes = GameObject.FindGameObjectsWithTag("DoNotDestroy")[0];
		collider = GetComponent<BoxCollider2D>();
		collider.enabled = false;
	}
	
	void FixedUpdate(){
		
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies.Length == 0){
			collider.enabled = true;
		}
		
		if (levelComplete){
			if (Input.GetAxis("Return") > 0){
				indexes.GetComponent<save_index>().LevelsCleared++;
				if(indexes.GetComponent<save_index>().LevelsCleared >= 3)
				{
					audio.Play();
					SceneManager.LoadScene (2);
				}
				else
				{
					int SceneNumber = Random.Range (3, 15);
					audio.Play();
        			SceneManager.LoadScene(SceneNumber);
				}
			}
		}
	}
	
	
    void OnTriggerEnter2D(Collider2D collision){
		
		
		
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player")){
			warning.SetActive(true);
			levelComplete = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player")){
			warning.SetActive(false);
			levelComplete = false;
		}
	}
}
