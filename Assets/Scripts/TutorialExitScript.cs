using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialExitScript : MonoBehaviour
{
    Character_Move player_0_Function;
    Player_1 player_1_Function;
    BaseDialogue baseDialogue;
    
    public static bool dialogueEnd = true;
    bool walkTowards = false;

    Animator player_0;
    Animator player_1;

    Vector2 p0localScale;
    Vector2 p1localScale;
    Vector2 position0;
    Vector2 position1;

    BoxCollider2D target;
    int p0;
    int p1;

    // Use this for initialization
    void Start ()
    {
        baseDialogue = GameObject.Find("BaseDialogue").GetComponent<BaseDialogue>();
        player_0_Function = GameObject.Find("Player_0").GetComponent<Character_Move>();
        player_1_Function = GameObject.Find("Player_1").GetComponent<Player_1>();
        player_0 = GameObject.Find("Player_0").GetComponent<Animator>();
        player_1 = GameObject.Find("Player_1").GetComponent<Animator>();
        
        if (PlayerPrefs.GetInt("PUZZLE") == 1 && !PlayerPrefs.HasKey("TUTORIALHUB"))
        {
            dialogueEnd = false;
            StartCoroutine(StartDialogue());
        }
	}

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(0.1f);
        walkTowards = true;
        target = GameObject.Find("Walk_Point").GetComponent<BoxCollider2D>();
        p0 = -2;
        p1 = -3;
        yield return new WaitUntil(() => !walkTowards);
        yield return new WaitForSeconds(1f);
        Flip1();
        yield return new WaitForSeconds(1f);
        BaseDialogue.scriptList = DialogueScripts.HubCS1P1;
        BaseDialogue.charName = DialogueScripts.HubCS1NameP1;
        baseDialogue.startDialogue();
        yield return new WaitUntil(() => BaseDialogue.dialogueEnd);
        walkTowards = true;
        target = GameObject.Find("Walk_Point2").GetComponent<BoxCollider2D>();
        p0 = -2;
        p1 = -1;
        yield return new WaitUntil(() => !walkTowards);
        yield return new WaitForSeconds(0.5f);
        BaseDialogue.scriptList = DialogueScripts.HubCS1P2;
        BaseDialogue.charName = DialogueScripts.HubCS1NameP2;
        yield return new WaitUntil(() => BaseDialogue.dialogueEnd);
        baseDialogue.startDialogue();
        dialogueEnd = true;

        PlayerPrefs.SetString("TUTORIALHUB", "DONE");
    }

    void WalkToTarget()
    {
        if (player_0_Function.transform.position.x != target.transform.position.x + p0)
        {
            position0 = target.transform.position;
            position0.x += p0;

            player_0_Function.transform.position = Vector2.MoveTowards(player_0_Function.transform.position, position0, 8f * Time.deltaTime);
            player_0.SetFloat("Speed", 8);
        }
        else
        {
            player_0.SetFloat("Speed", 0);
        }
        if (player_1_Function.transform.position.x != target.transform.position.x + p1)
        {
            position1 = target.transform.position;
            position1.x += p1;

            player_1_Function.transform.position = Vector2.MoveTowards(player_1_Function.transform.position, position1, 8f * Time.deltaTime);
            player_1.SetFloat("Speed", 8);
        }
        else
        {
            player_1.SetFloat("Speed", 0);
        }

        float move0 = player_0_Function.transform.position.x - position0.x;
        float move1 = player_1_Function.transform.position.x - position1.x;
        if ((player_0_Function.transform.localScale.x > 0 && move0 > 0.0f) || (player_0_Function.transform.localScale.x < 0 && move0 < 0.0f))
        {
            Flip0();
        }
        if ((player_1_Function.transform.localScale.x > 0 && move1 > 0.0f) || (player_1_Function.transform.localScale.x < 0 && move1 < 0.0f))
        {
            Flip1();
        }

        if (player_0_Function.transform.position.x == target.transform.position.x + p0 && player_1_Function.transform.position.x == target.transform.position.x + p1)
        {
            CancelInvoke("walkToTarget");
            walkTowards = false;
            player_0.SetFloat("Speed", 0);
            player_1.SetFloat("Speed", 0);
        }
    }

    void Update()
    {
        if (walkTowards)
            WalkToTarget();

        if (player_0_Function.enabled && !dialogueEnd)
        {
            player_0_Function.enabled = false;
            player_1_Function.enabled = false;
        }
    }

    void Flip0()
    {
        p0localScale = player_0_Function.transform.localScale;
        p0localScale.x *= -1;
        player_0_Function.transform.localScale = p0localScale;
    }

    void Flip1()
    {
        p1localScale = player_1_Function.transform.localScale;
        p1localScale.x *= -1;
        player_1_Function.transform.localScale = p1localScale;
    }
}
