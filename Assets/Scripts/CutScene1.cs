using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene1 : MonoBehaviour
{
    Character_Move player_0_Function;
    Player_1 player_1_Function;
    Transition_Scene transition;
    BaseDialogue baseDialogue;
    BoxCollider2D target;
    Animator player_0;
    Animator player_1;
    Image puzzle;
    Image door;

    string[] cutSceneScript1;
    bool cutScene = false;
    bool walkTowards = false;
    bool walkPuzzle = false;
    bool walkBack = false;
    bool Eden = false;
    bool Grant = false;

    Vector2 p0localScale;
    Vector2 p1localScale;


    SpriteRenderer p0;
    SpriteRenderer p1;

    // Use this for initialization
    void Start () {
        player_0_Function = GameObject.Find("Player_0").GetComponent<Character_Move>();
        player_1_Function = GameObject.Find("Player_1").GetComponent<Player_1>();
        transition = GameObject.Find("Transition").GetComponent<Transition_Scene>();
        baseDialogue = GameObject.Find("Tutorial").GetComponent<BaseDialogue>();
        target = GameObject.Find("CutScenePosition").GetComponent<BoxCollider2D>();
        player_0 = GameObject.Find("Player_0").GetComponent<Animator>();
        player_1 = GameObject.Find("Player_1").GetComponent<Animator>();
        puzzle = GameObject.Find("PuzzlePieces_1").GetComponent<Image>();
        door = GameObject.Find("Door_Open_Light_Top_Round").GetComponent<Image>();
        p0 = GameObject.Find("Player_0").GetComponent<SpriteRenderer>();
        p1 = GameObject.Find("Player_1").GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (walkTowards)
        {
            if (player_0_Function.transform.position.x != target.transform.position.x)
            {
                player_0_Function.transform.position = Vector2.MoveTowards(player_0_Function.transform.position, target.transform.position, 8f * Time.deltaTime);
                player_0.SetFloat("Speed", 8);
            } else
            {
                player_0.SetFloat("Speed", 0);
            }
            if (player_1_Function.transform.position.x != target.transform.position.x-1)
            {
                Vector2 position = target.transform.position;
                position.x -= 1;

                player_1_Function.transform.position = Vector2.MoveTowards(player_1_Function.transform.position, position, 8f * Time.deltaTime);
                player_1.SetFloat("Speed", 8);
            } else
            {
                player_1.SetFloat("Speed", 0);
            }

            if (player_0_Function.transform.localScale.x > 0)
            {
                Flip0();
            }
            if (player_1_Function.transform.localScale.x > 0)
            {
                Flip1();
            }

            if (player_0_Function.transform.position.x == target.transform.position.x && player_1_Function.transform.position.x == target.transform.position.x-1)
            {
                walkTowards = false;
                player_0.SetFloat("Speed", 0);
                player_1.SetFloat("Speed", 0);
            }
        }
        else if (walkPuzzle)
        {
            if (player_0_Function.transform.position.x != puzzle.transform.position.x)
            {
                player_0_Function.transform.position = Vector2.MoveTowards(player_0_Function.transform.position, puzzle.transform.position, 8f * Time.deltaTime);
                player_0.SetFloat("Speed", 8);
            }
            else
            {
                player_0.SetFloat("Speed", 0);
            }

            if (player_0_Function.transform.position.x == puzzle.transform.position.x)
            {
                walkPuzzle = false;
                player_0.SetFloat("Speed", 0);
            }
        }
        else if (walkBack)
        {
            if (player_0_Function.transform.position.x != target.transform.position.x)
            {
                player_0_Function.transform.position = Vector2.MoveTowards(player_0_Function.transform.position, target.transform.position, 8f * Time.deltaTime);
                player_0.SetFloat("Speed", 8);
            }
            else
            {
                player_0.SetFloat("Speed", 0);
            }

            if (player_0_Function.transform.localScale.x > 0)
            {
                Flip0();
            }

            if (player_0_Function.transform.position.x == target.transform.position.x)
            {
                walkBack = false;
                player_0.SetFloat("Speed", 0);
            }
        }
        else if (Eden)
        {
            if (player_1_Function.transform.position.x != door.transform.position.x)
            {
                player_1_Function.transform.position = Vector2.MoveTowards(player_1_Function.transform.position, door.transform.position, 8f * Time.deltaTime);
                player_1.SetFloat("Speed", 8);
            }
            else
            {
                player_1.SetFloat("Speed", 0);
            }

            if (player_1_Function.transform.position.x == door.transform.position.x)
            {
                Eden = false;
                player_1.SetFloat("Speed", 0);
            }
        }
        else if (Grant)
        {
            if (player_0_Function.transform.position.x != door.transform.position.x)
            {
                player_0_Function.transform.position = Vector2.MoveTowards(player_0_Function.transform.position, door.transform.position, 8f * Time.deltaTime);
                player_0.SetFloat("Speed", 8);
            }
            else
            {
                player_0.SetFloat("Speed", 0);
            }

            if (player_0_Function.transform.position.x == door.transform.position.x)
            {
                Grant = false;
                player_0.SetFloat("Speed", 0);
            }
        }
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player_0")
        {
            if (!cutScene)
            {
                StartCoroutine(StartCutScene());
                cutScene = true;
            }
        }
    }

    IEnumerator StartCutScene()
    {
        player_1.SetInteger("Animate", 0);
        yield return new WaitForSeconds(0.5f);
        disablePlayers();
        yield return new WaitForSeconds(1f);
        walkTowards = true;
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => !walkTowards);
        Flip0();
        Flip1();

        yield return new WaitForSeconds(1f);
        BaseDialogue.scriptList = DialogueScripts.TutorialCS3P1;
        BaseDialogue.charName = DialogueScripts.TutorialCS3NameP1;
        baseDialogue.startDialogue();
        yield return new WaitUntil(() => BaseDialogue.dialogueEnd);
        disablePlayers();
        yield return new WaitForSeconds(0.5f);
        walkPuzzle = true;
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => !walkPuzzle);
        Destroy(puzzle.gameObject);
        PlayerPrefs.SetInt("PUZZLE", 1);
        walkBack = true;
        yield return new WaitUntil(() => !walkBack);
        Flip0();
        yield return new WaitForSeconds(1f);

        BaseDialogue.scriptList = DialogueScripts.TutorialCS3P2;
        BaseDialogue.charName = DialogueScripts.TutorialCS3NameP2;
        baseDialogue.startDialogue();

        yield return new WaitUntil(() => BaseDialogue.dialogueEnd);
        disablePlayers();
        Eden = true;
        yield return new WaitUntil(() => !Eden);
        p1.enabled = false;
        Grant = true;
        yield return new WaitUntil(() => !Grant);
        p0.enabled = false;
        yield return new WaitForSeconds(1f);
        transition.load("HubWorld");

    }

    void disablePlayers()
    {
        player_0_Function.enabled = false;
        player_1_Function.enabled = false;
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
