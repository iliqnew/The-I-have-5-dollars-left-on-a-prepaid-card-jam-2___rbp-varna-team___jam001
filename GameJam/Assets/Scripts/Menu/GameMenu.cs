using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
	public void ResumeTime(){
		Time.timeScale = 1;
	}
	
	public void ExitGame(){
		Application.Quit();
	}
}
