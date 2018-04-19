using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {
    Transition_Scene transition;
	// Use this for initialization
    void Start()
    {
        transition = FindObjectOfType<Transition_Scene>();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(PlayerPrefs.GetInt("LEVEL"));
        int level = PlayerPrefs.GetInt("LEVEL") + 1;
        Debug.Log(level);
        transition.load("Level_" + level);
    }
}
