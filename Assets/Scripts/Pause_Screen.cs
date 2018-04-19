using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Screen : MonoBehaviour {
    Character_Move p0;
    Pause_Game pause;
    Transition_Scene transition;
	// Use this for initialization
	void Start () {
        p0 = GameObject.Find("Player_0").GetComponent<Character_Move>();
        pause = GameObject.Find("PauseListen").GetComponent<Pause_Game>();
        transition = GameObject.Find("Transition").GetComponent<Transition_Scene>();
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void Reseme()
    {
        pause.UnPause();
    }

    public void Restart()
    {
        pause.UnPause();
        p0.EnableMovement();
        transition.load(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        pause.UnPause();
        p0.EnableMovement();
        transition.load("Menu_Scene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
