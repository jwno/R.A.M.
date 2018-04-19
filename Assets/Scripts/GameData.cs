using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    int level;
	// Use this for initialization
    void Start()
    {
        string scene = SceneManager.GetActiveScene().name;
        if (scene != "Menu_Scene")
        {
            char lv = scene[scene.Length - 1];
            level = int.Parse(lv.ToString());
            PlayerPrefs.SetInt("LEVEL", level);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
