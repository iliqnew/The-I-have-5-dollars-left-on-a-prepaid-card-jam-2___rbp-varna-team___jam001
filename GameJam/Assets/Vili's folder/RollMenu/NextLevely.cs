using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevely : MonoBehaviour
{
    public void LoadRandomLevel()
    {
        int SceneNumber = Random.Range (3, 15);
        SceneManager.LoadScene(SceneNumber);
    }
}