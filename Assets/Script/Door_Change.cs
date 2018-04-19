using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Change : MonoBehaviour {
    Transition_Scene transition;
	// Use this for initialization
    void Start()
    {
        transition = FindObjectOfType<Transition_Scene>();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        int level = PlayerPrefs.GetInt("LEVEL")+1;
        transition.load("Level_" + level);
    }
}

