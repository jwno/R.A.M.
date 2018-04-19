using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open_Hub_Doors : MonoBehaviour 
{
	Collider2D player;
    bool exit = false;
    Transition_Scene transition;
    int num;

    private void Start()
    {
        transition = GameObject.Find("Transition").GetComponent<Transition_Scene>();
        char c = this.name[this.name.Length - 1];
        num = int.Parse(c.ToString());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player_0")
        {
            if (PlayerPrefs.GetInt("PUZZLE") >= num)
            {
                exit = false;
                InvokeRepeating("WaitF", 0, 0.01667f);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player_0")
        {
            exit = true;
        }
    }

    private void WaitF()
    {
        if (exit)
        {
            CancelInvoke("WaitF");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F) && TutorialExitScript.dialogueEnd)
            {
                transition.load("Level_" + num);
            }
        }
    }
}
