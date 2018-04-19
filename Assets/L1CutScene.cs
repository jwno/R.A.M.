using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1CutScene : MonoBehaviour
{
    Character_Move player_0_Function;
    Player_1 player_1_Function;
    BaseDialogue baseDialogue;
    bool dialogueEnd = true;

    public string[] script;
    public string[] names;

	// Use this for initialization
	void Start () {

        baseDialogue = GameObject.Find("BaseDialogue").GetComponent<BaseDialogue>();
        player_0_Function = GameObject.Find("Player_0").GetComponent<Character_Move>();
        player_1_Function = GameObject.Find("Player_1").GetComponent<Player_1>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dialogueEnd)
        {
            dialogueEnd = false;
            BaseDialogue.scriptList = script;
            BaseDialogue.charName = names;
            baseDialogue.startDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player_0_Function.enabled && !dialogueEnd)
        {
            player_0_Function.enabled = false;
            player_1_Function.enabled = false;
        }
        if (!dialogueEnd && BaseDialogue.dialogueEnd)
        {
            player_0_Function.enabled = true;
            player_1_Function.enabled = true;
            this.enabled = false;
        }
    }
}
