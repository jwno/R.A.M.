using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Transport_lvl_2 : MonoBehaviour {
	[SerializeField]Transform spawn_point;
    bool exit = false;
    Collider2D player_0;
    Collider2D player_1;

    private void Start()
    {
        player_0 = GameObject.Find("Player_0").GetComponent<Collider2D>();
        player_1 = GameObject.Find("Player_1").GetComponent<Collider2D>();
    }

    private static Dictionary<string, string> door_dict = new Dictionary<string, string>()
	{
		{"Open_Snow_To_Sand", "Sand_Key"},
		{"Open_Sand_To_Snow", "Sand_Key"},
		{"Open_Sand_To_Grass_Bottom", "Grass_Bottom_Key"},
		{"Open_Sand_To_Grass", "Grass_Bottom_Key"},
		{"Open_Grass_Bottom_To_Night","Night_Key"},
		{"Open_Night_To_Grass_Bottom", "Night_Key"},
		{"Open_Night_To_Grass_Top", "Grass_Top_Key"},
		{"Open_Grass_Top_To_Night", "Grass_Top_Key"},
		{"Open_Snow_To_Final", "Final_Key"},
		{"Open_Final_To_Snow", "Final_Key"},
		{"Open_Snow_To_Night", "Night_To_Snow_Key"},
		{"Open_Night_To_Snow", "Night_To_Snow_Key"}
	};

	private void OnTriggerEnter2D(Collider2D collision){
		if ( (collision.transform.CompareTag ("Player_0"))) {
			if (door_dict.ContainsKey (this.gameObject.name)) {
				string key_name = door_dict [this.gameObject.name];
				if (GameVariables.key_dict[key_name] == true)
                {
                    exit = false;
                    InvokeRepeating("WaitF", 0, 0.01667f);
                }
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                player_0.transform.position = spawn_point.position;
                Vector2 p0 = spawn_point.position;
                p0.x = p0.x - 1;
                player_1.transform.position = p0;
            }
        }
    }
}