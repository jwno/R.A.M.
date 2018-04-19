using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    Character_Move player_0_Function;
    Player_1 player_1_Function;
    BaseDialogue baseDialogue;

    public string[] CharacterScript;
    public string[] CharacterName;
    bool dialogueEnd = true;
    bool walkTowards = false;

    BoxCollider2D FinalPosition;

    Animator player_0;
    Animator player_1;

    Vector2 p0localScale;
    Vector2 p1localScale;

    Transition_Scene transition;

    // Use this for initialization
    void Start()
    {
        baseDialogue = GameObject.Find("BaseDialogue").GetComponent<BaseDialogue>();
        player_0_Function = GameObject.Find("Player_0").GetComponent<Character_Move>();
        player_1_Function = GameObject.Find("Player_1").GetComponent<Player_1>();
        player_0 = GameObject.Find("Player_0").GetComponent<Animator>();
        player_1 = GameObject.Find("Player_1").GetComponent<Animator>();
        FinalPosition = GameObject.Find("FinalPosition").GetComponent<BoxCollider2D>();
        transition = GameObject.Find("Transition").GetComponent<Transition_Scene>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player_0" && PlayerPrefs.GetInt("PUZZLE") == 3 && dialogueEnd)
        {
            dialogueEnd = false;
            StartCoroutine(StartDialogue());
        }
    }


    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(0.1f);
        disablePlayers();
        yield return new WaitForSeconds(0.5f);
        walkTowards = true;
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => !walkTowards);
        if (player_0_Function.transform.localScale.x > 0)
        {
            Flip0();
        }
        yield return new WaitForSeconds(1f);
        BaseDialogue.scriptList = CharacterScript;
        BaseDialogue.charName = CharacterName;
        baseDialogue.startDialogue();
        yield return new WaitUntil(() => BaseDialogue.dialogueEnd);
        Flip0();
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

    private void Update()
    {
        if (walkTowards)
        {
            if (player_0_Function.transform.position.x != FinalPosition.transform.position.x)
            {
                player_0_Function.transform.position = Vector2.MoveTowards(player_0_Function.transform.position, FinalPosition.transform.position, 8f * Time.deltaTime);
                player_0.SetFloat("Speed", 8);
            }
            else
            {
                player_0.SetFloat("Speed", 0);
            }
            if (player_1_Function.transform.position.x != FinalPosition.transform.position.x - 1)
            {
                Vector2 position = FinalPosition.transform.position;
                position.x -= 1;

                player_1_Function.transform.position = Vector2.MoveTowards(player_1_Function.transform.position, position, 8f * Time.deltaTime);
                player_1.SetFloat("Speed", 8);
            }
            else
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

            if (player_0_Function.transform.position.x == FinalPosition.transform.position.x && player_1_Function.transform.position.x == FinalPosition.transform.position.x - 1)
            {
                walkTowards = false;
                player_0.SetFloat("Speed", 0);
                player_1.SetFloat("Speed", 0);
            }
        }
    }
}
