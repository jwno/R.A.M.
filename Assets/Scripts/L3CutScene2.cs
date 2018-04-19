using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3CutScene2 : MonoBehaviour {
    BaseDialogue baseDialogue;

    public string[] CharacterScript;
    public string[] CharacterName;
    bool dialogueEnd = true;

    // Use this for initialization
    void Start()
    {
        baseDialogue = GameObject.Find("BaseDialogue").GetComponent<BaseDialogue>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player_0" && dialogueEnd)
        {
            dialogueEnd = false;
            StartCoroutine(StartDialogue());
        }
    }


    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(0.1f);

        BaseDialogue.scriptList = CharacterScript;
        BaseDialogue.charName = CharacterName;
        baseDialogue.startDialogue();
        yield return new WaitUntil(() => BaseDialogue.dialogueEnd);
        this.enabled = false;
    }
}
