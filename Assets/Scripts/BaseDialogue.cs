using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDialogue : MonoBehaviour {
    Canvas dialogue_Canvas;
    Dialogue dialogue;
    Text charNames;
    Character_Move player_0_Function;
    Player_1 player_1_Function;

    public string[] characterName;
    public string[] characterScript;

    public static string[] charName;
    public static string[] scriptList;
    public static bool dialogueEnd = true;

    public static bool choice = false;

    bool exit = false;

    // Use this for initialization
    void Start()
    {
        dialogue_Canvas = GameObject.Find("TextCanvas").GetComponent<Canvas>();
        dialogue_Canvas.enabled = false;
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
        charNames = GameObject.Find("Name").GetComponent<Text>();
        player_0_Function = GameObject.Find("Player_0").GetComponent<Character_Move>();
        player_1_Function = GameObject.Find("Player_1").GetComponent<Player_1>();
    }
    public void manualDialogue()
    {
        dialogueEnd = false;
        charName = characterName;
        scriptList = characterScript;
        StartCoroutine(StartTalking());
    }

    public void startDialogue()
    {
        dialogueEnd = false;
        StartCoroutine(StartTalking());
    }

    
    IEnumerator StartTalking()
    {
        player_0_Function.enabled = false;
        player_1_Function.enabled = false;
        ContinueDialogue();
        dialogue_Canvas.enabled = true;
        for (int i = 0; i < scriptList.Length; i++) {
            charNames.text = charName[i];
            yield return new WaitUntil(() => !dialogue.isTyping);
            yield return new WaitUntil(() => Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && !Pause_Game.pause);
        }
        dialogue_Canvas.enabled = false;
        yield return new WaitForSeconds(0.5f);
        player_0_Function.enabled = true;
        player_1_Function.enabled = true;
        dialogueEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ContinueDialogue()
    {
        dialogue.AddNewDialogue(scriptList);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player_0")
        {
            exit = false;
            InvokeRepeating("WaitF", 0, 0.01667f);
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
            if (Input.GetKeyDown(KeyCode.F) && dialogueEnd)
            {
                manualDialogue();
            }
        }
    }
}
