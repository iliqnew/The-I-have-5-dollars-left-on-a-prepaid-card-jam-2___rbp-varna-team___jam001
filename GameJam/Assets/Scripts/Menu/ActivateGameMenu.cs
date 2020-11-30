using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameMenu : MonoBehaviour
{
	public GameObject MenuCanvas;
	public GameObject Manu;
	public GameObject OptionMenu;
	
    void Update()
    {
        if (Input.GetKeyDown("escape")){
			if (MenuCanvas.activeSelf){
				
				Time.timeScale = 1;
				MenuCanvas.SetActive(false);
				
			}
			else{
				Time.timeScale = 0;
				MenuCanvas.SetActive(true);
			}
		}
    }
}
