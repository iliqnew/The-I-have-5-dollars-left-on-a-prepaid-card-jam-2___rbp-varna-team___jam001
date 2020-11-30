using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
	private save_index imortalScript;
	public TextMeshProUGUI score;
	
	void Start(){
		Time.timeScale = 0;
		imortalScript = GameObject.FindGameObjectsWithTag("DoNotDestroy")[0].GetComponent<save_index>();
		score.text = imortalScript.LevelsCleared.ToString();
	}
	
	public void ExitGame(){
		Application.Quit();
	}
	
	public void TryAgain(){
		imortalScript.modifierCount = 0;
		imortalScript.LevelsCleared = 0;
		Time.timeScale = 1;
		SceneManager.LoadScene(1);
	}
}
