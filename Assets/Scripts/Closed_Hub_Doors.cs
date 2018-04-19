using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closed_Hub_Doors : MonoBehaviour
{
    BaseDialogue baseDialogue;
    bool exit = true;
    void Awake()
    {
        if (PlayerPrefs.HasKey(this.gameObject.name))
            Destroy(this.gameObject);
    }

    private void Start()
    {
        baseDialogue = GameObject.Find("BaseDialogue").GetComponent<BaseDialogue>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        char c = this.name[this.name.Length-1];
        int num = int.Parse(c.ToString());

		if (collision.tag == "Player_0") {
            Debug.Log(PlayerPrefs.GetInt("PUZZLE") + " : " + num);
            if (!PlayerPrefs.HasKey(this.name) && num <= PlayerPrefs.GetInt("PUZZLE"))
            {
                PlayerPrefs.SetString(this.name, "Open");
                Destroy(this.gameObject);
            } else
            {
                exit = false;
                InvokeRepeating("WaitF", 0, 0.01667f);
            }  
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
            if (Input.GetKeyDown(KeyCode.F) && TutorialExitScript.dialogueEnd)
            {
                BaseDialogue.scriptList = new string[] { "Looks like we can't go in this one yet." };
                BaseDialogue.charName = new string[] { "Eden" };
                baseDialogue.startDialogue();
            }
        }
    }
}
