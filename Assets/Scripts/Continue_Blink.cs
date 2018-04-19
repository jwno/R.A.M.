using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue_Blink : MonoBehaviour {
    Image button;
    bool condition;
    bool updateCondition = true;
    Dialogue dialogue;
	// Use this for initialization
	void Start () {
        condition = false;
        button = GameObject.Find("Blink_Button").GetComponent<Image>();
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
        button.enabled = false;
	}

    void Update()
    {
        if (!dialogue.isTyping && updateCondition)
        {
            updateCondition = false;
            button.enabled = true;
            InvokeRepeating("blink", 0.5f, 0.5f);
        }
    }

    void blink()
    {
        if (dialogue.isTyping)
        {
            updateCondition = true;
            button.enabled = false;
            CancelInvoke("blink");
        }
        else if (condition)
        {
            button.enabled = true;
            condition = false;
        }
        else
        {
            button.enabled = false;
            condition = true;
        }
    }
}
