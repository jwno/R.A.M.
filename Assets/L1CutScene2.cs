using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1CutScene2 : MonoBehaviour {
    Character_Move player_0_Function;
    Player_1 player_1_Function;
    BaseDialogue baseDialogue;
    bool dialogueEnd = true;
    Transition_Scene transition;

    Animator p0;
    Animator p1;

    public string[] script;
    public string[] names;

    // Use this for initialization
    void Start()
    {

        baseDialogue = GameObject.Find("BaseDialogue").GetComponent<BaseDialogue>();
        player_0_Function = GameObject.Find("Player_0").GetComponent<Character_Move>();
        player_1_Function = GameObject.Find("Player_1").GetComponent<Player_1>();
        p0 = GameObject.Find("Player_0").GetComponent<Animator>();
        p1 = GameObject.Find("Player_1").GetComponent<Animator>();
        transition = GameObject.Find("Transition").GetComponent<Transition_Scene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dialogueEnd)
        {
            dialogueEnd = false;
            StartCoroutine(StartDialogue());
        }
    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1f);
        p0.SetFloat("Speed", 0);
        p1.SetFloat("Speed", 0);
        BaseDialogue.scriptList = script;
        BaseDialogue.charName = names;
        baseDialogue.startDialogue();
        yield return new WaitUntil(() => BaseDialogue.dialogueEnd);
        yield return new WaitForSeconds(1f);
        transition.load("HubWorld");
    }

    // Update is called once per frame
    void Update()
    {
        if (player_0_Function.enabled && !dialogueEnd)
        {
            player_0_Function.enabled = false;
            player_1_Function.enabled = false;
        }
    }
}
