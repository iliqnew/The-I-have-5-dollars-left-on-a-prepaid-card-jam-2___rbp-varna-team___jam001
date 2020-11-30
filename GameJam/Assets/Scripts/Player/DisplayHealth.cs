using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
	
	public PlayerController playerScript;
	public int exHealth;
	
    public GameObject healthImage1;
	public GameObject healthImage2;
	public GameObject healthImage3;
	public GameObject healthImage4;
	public GameObject healthImage5;
	public GameObject healthImage6;
	public GameObject healthImage7;
	public GameObject healthImage8;
	
    public void FixedUpdate(){
		if (playerScript.health != exHealth){
			exHealth = playerScript.health;
			
			if (exHealth < 1){
				healthImage1.SetActive(false);
			}
			else{
				healthImage1.SetActive(true);
			}
			
			if (exHealth < 2){
				healthImage2.SetActive(false);
			}
			else{
				healthImage2.SetActive(true);
			}
			
			if (exHealth < 3){
				healthImage3.SetActive(false);
			}
			else{
				healthImage3.SetActive(true);
			}
			
			if (exHealth < 4){
				healthImage4.SetActive(false);
			}
			else{
				healthImage4.SetActive(true);
			}
			
			if (exHealth < 5){
				healthImage5.SetActive(false);
			}
			else{
				healthImage5.SetActive(true);
			}
			if (exHealth < 6){
				healthImage6.SetActive(false);
			}
			else{
				healthImage6.SetActive(true);
			}
			if (exHealth < 7){
				healthImage7.SetActive(false);
			}
			else{
				healthImage7.SetActive(true);
			}
			if (exHealth < 8){
				healthImage8.SetActive(false);
			}
			else{
				healthImage8.SetActive(true);
			}
		}
    }
}
