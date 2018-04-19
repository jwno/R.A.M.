using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Image black;
    Canvas dialogue_Canvas;
    Dialogue dialogue;
    Color color;
    List<string[]> tut_list = new List<string[]>();
    Text charName;
    Character_Move player_0_Function;
    Player_1 player_1_Function;
    Transition_Scene transition;
    Text choice1, choice2;
    BaseDialogue baseDialogue;

    string[] tut_string;
    int dNum = 0;
    float alpha = 1f;
    float fadeSpeed = 0.001f;
    bool fade = false;
    bool fadeBlack = false;
    bool dialogueEnd;

    public static bool choice = false;

    // Use this for initialization
    void Start()
    {
        black = GameObject.Find("Tutorial").GetComponent<Image>();
        dialogue_Canvas = GameObject.Find("TextCanvas").GetComponent<Canvas>();
        dialogue_Canvas.enabled = false;
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
        charName = GameObject.Find("Name").GetComponent<Text>();
        player_0_Function = GameObject.Find("Player_0").GetComponent<Character_Move>();
        player_1_Function = GameObject.Find("Player_1").GetComponent<Player_1>();
        transition = GameObject.Find("Transition").GetComponent<Transition_Scene>();
        choice1 = GameObject.Find("Choice1").GetComponent<Text>();
        choice2 = GameObject.Find("Choice2").GetComponent<Text>();
        baseDialogue = GameObject.Find("Tutorial").GetComponent<BaseDialogue>();
        
        tut_list = DialogueScripts.TutorialCS1;
        if (!PlayerPrefs.HasKey("TUTORIAL"))
        {
            dialogueEnd = false;
            StartCoroutine(InitialDialogue());
        }
        else
        {
            dialogueEnd = true;
            black.enabled = false;
            player_0_Function.transform.Translate(Vector3.up * 1f, Space.World);
            player_0_Function.transform.rotation = Quaternion.Euler(0, 0, 0);
            player_0_Function.enabled = true;
            player_1_Function.enabled = true;
        }
    }


    IEnumerator InitialDialogue()
    {
        player_0_Function.enabled = false;
        player_1_Function.enabled = false;
        yield return new WaitForSeconds(2f);
        charName.text = "???";
        tut_string = tut_list[dNum];
        ContinueDialogue();
        dNum++;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitUntil(() => dialogue.next);
        dialogue_Canvas.enabled = false;
        fadeSpeed = 0.0005f;
        fade = true;
        yield return new WaitUntil(() => alpha <= 0.9f);
        fade = false;
        tut_string = tut_list[dNum];
        ContinueDialogue();
        dNum++;

        yield return new WaitUntil(() => dialogue.next);
        dialogue_Canvas.enabled = false;
        fadeBlack = true;
        yield return new WaitUntil(() => alpha >= 0.95f);
        yield return new WaitForSeconds(2f);
        fadeBlack = false;
        fadeSpeed = 0.001f;
        fade = true;
        yield return new WaitUntil(() => alpha <= 0.75f);
        fade = false;
        yield return new WaitForSeconds(1f);
        tut_string = tut_list[dNum];
        ContinueDialogue();

        yield return new WaitUntil(() => dialogue.next);
        dialogue_Canvas.enabled = false;
        fadeSpeed = 0.01f;
        fade = true;

        yield return new WaitUntil(() => alpha <= 0.1f);
        fade = false;
        black.enabled = false;
        List<string[]> optional = new List<string[]>();
        optional = DialogueScripts.TutorialCS1OptionalQ;
        choice = true;
        for (int i = 0; i < 3; i++)
        {
            tut_string = optional[i];
            ContinueDialogue();
            yield return new WaitUntil(() => !dialogue.isTyping);
            choice1.enabled = true;
            choice1.text = DialogueScripts.TutorialCS1Optional1[i];
            choice2.enabled = true;
            choice2.text = DialogueScripts.TutorialCS1Optional2[i];
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)));
            choice1.enabled = false;
            choice2.enabled = false;
            if (Dialogue.choiceNumber == 2)
            {
                break;
            }
            else if (i == 2)
                transition.load("Menu_Scene");
        }
        dialogue_Canvas.enabled = false;

        yield return new WaitForSeconds(1f);
        player_0_Function.transform.Translate(Vector3.up * 1f, Space.World);
        player_0_Function.transform.rotation = Quaternion.Euler(0, 0, 0);
        yield return new WaitForSeconds(1f);
        Vector2 localScale = player_0_Function.transform.localScale;
        localScale.x *= -1;
        player_0_Function.transform.localScale = localScale;
        yield return new WaitForSeconds(0.75f);
        localScale.x *= -1;
        player_0_Function.transform.localScale = localScale;
        yield return new WaitForSeconds(0.75f);
        localScale.x *= -1;
        player_0_Function.transform.localScale = localScale;
        yield return new WaitForSeconds(0.75f);
        BaseDialogue.scriptList = DialogueScripts.TutorialCS2;
        BaseDialogue.charName = DialogueScripts.TutorialCS2Name;
        baseDialogue.startDialogue();
        yield return new WaitUntil(() => BaseDialogue.dialogueEnd);
        dialogueEnd = true;
        localScale.x *= -1;
        player_0_Function.transform.localScale = localScale;

        player_0_Function.enabled = true;
        player_1_Function.enabled = true;

        PlayerPrefs.SetString("TUTORIAL", "DONE");
    }


    // Update is called once per frame
    void Update()
    {
        if (player_0_Function.enabled && !dialogueEnd)
        {
            player_0_Function.enabled = false;
            player_1_Function.enabled = false;
        }

        if (fade)
        {
            alpha -= fadeSpeed;
            black.color = new Color(1, 1, 1, alpha);
        }
        else if (fadeBlack)
        {
            alpha += fadeSpeed;
            black.color = new Color(1, 1, 1, alpha);
        }
    }

    void ContinueDialogue()
    {
        dialogue_Canvas.enabled = true;
        dialogue.AddNewDialogue(tut_string);
    }
}
