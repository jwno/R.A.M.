using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string[] dialogue;
    List<string> dialogueLines = new List<string>();
    public float typeSpeed;
    public bool endDialogue = false;
    public static int choiceNumber = 0;

    private bool cancelTyping = false;

    public bool isTyping = false;
    Text dialogueText;
    int dialogueIndex;
    public bool next = false;

    // Use this for initialization
    void Start()
    {
        dialogueText = GameObject.Find("Dialogue").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && !Pause_Game.pause)
        {
            if (!isTyping)
            {
                next = true;
                Continue_Dialogue();
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    private IEnumerator textScroll(string lineofText)
    {
        int letter = 0;
        dialogueText.text = "";
        isTyping = true;
        cancelTyping = false;
        next = false;
        while (isTyping && !cancelTyping && letter < lineofText.Length - 1)
        {
            dialogueText.text += lineofText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        dialogueText.text = lineofText;
        isTyping = false;
        cancelTyping = false;
    }

    public void AddNewDialogue(string[] lines)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        //dialogueLines.AddRange(lines);
        foreach (string line in lines)
        {
            dialogueLines.Add(line);
        }
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        // Start Dialogue
        StartCoroutine(textScroll(dialogueLines[dialogueIndex]));
        //dialogueText.text = dialogueLines[dialogueIndex];
        dialogueText.enabled = true;
    }

    public void Continue_Dialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            // Continue Dialogue
            dialogueIndex++;
            StartCoroutine(textScroll(dialogueLines[dialogueIndex]));
            //dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            if (Tutorial.choice)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    choiceNumber = 1;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    choiceNumber = 2;
                }
            }
            else
            {
                dialogueText.enabled = false;
                endDialogue = true;
            }
        }
    }
}
