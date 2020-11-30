using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RollDice : MonoBehaviour
{
	public GameObject continue_button;
	public GameObject indexes;
	public int number_of_roll;
	public int roll_max;
	public string[] RollTable;
	public GameObject[] text_fields;
	public GameObject[] dice;
	public GameObject button;
	public float x_offset;
	public int levelsCompleted;
	//private GameObject target;
	
	Vector3[] face_pos = new Vector3[]{new Vector3(-27.78f,-6.2f,181.6f),
	new Vector3(-140.6f,161.1f,121.6f),new Vector3(62.3f,234.8f,81.2f),
	new Vector3(-134.8f,202.1f,164.1f),new Vector3(-89.9f,11.6f,133.9f),
	new Vector3(213.1f, -107.4f, 179.6f), new Vector3(61f, 126.7f,203.2f),
	new Vector3(88.5f,55.9f,203.2f),new Vector3(136.5f,-377f,345f),
	new Vector3(-46.9f,-60.5f,-76.8f),new Vector3(133.2f,21.5f,-54.2f),
	new Vector3(-205.6f,17.5f,-175.94f)};	
    // Start is called before the first frame update
	void Start()
	{
		indexes = GameObject.FindGameObjectsWithTag("DoNotDestroy")[0];
		levelsCompleted = indexes.GetComponent<save_index>().LevelsCleared;
		levelsCompleted /= 3;
		if(levelsCompleted > 3) levelsCompleted = 3;
		number_of_roll = levelsCompleted;
		indexes.GetComponent<save_index>().modifierCount = number_of_roll;

		continue_button.SetActive(false);
		Vector2 die_anchor_min;
		Vector2 die_anchor_max;
		foreach(GameObject g in text_fields)
		{
			g.SetActive(false);
		}
		
		//DistBox = Mathf.Abs(DiceBox1 - DiceBox2);
		float x_bumper;
		Vector2 die_pivot;
		for(int i = 0; i<number_of_roll; i++) 
		{
			Debug.Log(i);
			dice[i].SetActive(true);
			//Debug.Log((1)/(number_of_roll+1f));
			x_bumper = (((1f)/(number_of_roll+1))*(i+1));
			die_pivot = new Vector2(x_bumper,dice[i].GetComponent<RectTransform>().pivot.y);
			
			Debug.Log(die_pivot);
			
			
			//Vector3 new_x_Vector3 = new Vector3((DiceBox1+((DistBox/(number_of_roll+1))*(i+1)))*autism_scale,dice[i].transform.position.y, dice[i].transform.position.z);
			//Debug.Log(DistBox);
			//Debug.Log(DiceBox1+((DistBox/(number_of_roll+1))*(i+1)));
		
			//Debug.Log(new_x_Vector3);
			dice[i].GetComponent<RectTransform>().pivot = die_pivot;
			
			
		}
		
		foreach(GameObject d in dice)
		{
			d.GetComponent<MonoBehaviour>().enabled = false;
		}
		
	}
	
    public void On_click()
    {
		Debug.Log(number_of_roll);
		foreach(GameObject d in dice)
		{
			d.GetComponent<MonoBehaviour>().enabled = true;
		}
		StartCoroutine(ClickEvents(3f));
    }
	
	
	public IEnumerator ClickEvents (float seconds)
	{
		indexes.GetComponent<save_index>().modifierCount = number_of_roll;
		yield return new WaitForSeconds(3);
		foreach(GameObject d in dice)
		{
			d.GetComponent<MonoBehaviour>().enabled = false;
		}
		transform.Rotate(new Vector3(Random.value, Random.value, Random.value));
		indexes.GetComponent<save_index>().modifier_indexes.Clear();
		
		// add code that directs the dice
		
		for(int i = 0; i<number_of_roll; i++) 
		{
			int roll =  Random.Range(0,roll_max);
			indexes.GetComponent<save_index>().modifier_indexes.Add(roll);
		}
		
		for(int i = 0; i<number_of_roll; i++)
		{
			//Debug.Log(face_pos[indexes.GetComponent<save_index>().modifier_indexes[i]]);
			dice[i].transform.eulerAngles = face_pos[indexes.GetComponent<save_index>().modifier_indexes[i]];
		}
		
		for(int i = 0; i<number_of_roll; i++)
		{
			text_fields[i].SetActive(true);
			TextMeshProUGUI roll_text = text_fields[i].GetComponent<TextMeshProUGUI>();
			roll_text.text = RollTable[indexes.GetComponent<save_index>().modifier_indexes[i]];
			
		}
	
		

		Debug.Log(indexes.GetComponent<save_index>().modifier_indexes[0]);
		Destroy(button);
		continue_button.SetActive(true);
		
		
	}
	
}

    

