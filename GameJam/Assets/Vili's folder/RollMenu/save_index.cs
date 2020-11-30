using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_index : MonoBehaviour
{
	public List<int> modifier_indexes = new List<int>();
    public int modifierCount = 0;
    public int LevelsCleared = 0;
	
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
   
}
