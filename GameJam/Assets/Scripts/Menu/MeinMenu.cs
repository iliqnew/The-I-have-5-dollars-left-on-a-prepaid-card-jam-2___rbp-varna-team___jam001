using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeinMenu : MonoBehaviour
{
	public GameObject loadingScreen;
	public Slider slider;
	public Image loadingImage;
	
    public void LoadNextScene(){
		StartCoroutine(LoadAsync(SceneManager.GetActiveScene().buildIndex + 1));
	}
	
	public void ExitGame(){
		Application.Quit();
	}
	
	IEnumerator LoadAsync(int sceneIndex){
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
		
		loadingScreen.SetActive(true);
		
		while (!operation.isDone){
			float progress = Mathf.Clamp01(operation.progress / 0.9f);
			
			slider.value = progress;
			loadingImage.fillAmount = progress;
			
			yield return null;
		}
	}
}
