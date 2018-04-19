using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Button : MonoBehaviour {
    Transition_Scene transition;
	// Use this for initialization
	void Start () {
        transition = FindObjectOfType<Transition_Scene>();
	}

    
    public void Resume()
    {
        if (PlayerPrefs.HasKey("LEVEL")) {
            transition.load("Level_" + PlayerPrefs.GetInt("LEVEL"));
        }
        else
        {
            Debug.Log("EMPTY!!!");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
