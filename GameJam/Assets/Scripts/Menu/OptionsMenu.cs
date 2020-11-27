using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Slider slider;
	
	public void Start(){
		audioMixer.GetFloat("Master", out float fill);
		slider.value = fill;
	}
	
    public void SetMasterVolume(float volume){
		audioMixer.SetFloat("Master", volume);
	}
	
	public void SetFullScreen(bool FullScreen){
		Screen.fullScreen = FullScreen;
	}
}
