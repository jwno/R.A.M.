using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private static Dictionary<string, string> door_dict = new Dictionary<string, string>()
	{
		{"Closed_Snow_To_Sand", "Sand_Key"},
		{"Closed_Sand_To_Grass", "Grass_Bottom_Key"},
		{"Closed_Grass_Bottom_To_Night", "Night_Key"},
		{"Closed_Night_To_Grass_Top", "Grass_Top_Key"},
		{"Closed_Snow_To_Final", "Final_Key"},
		{"Closed_Night_To_Snow", "Night_To_Snow_Key"}
	};
	
	private void OnTriggerEnter2D(Collider2D collision){
		if ((collision.gameObject.name == "Player_0")) {
			if (door_dict.ContainsKey (this.gameObject.name)) {
				string key_name = door_dict [this.gameObject.name];
				if (GameVariables.key_dict [key_name] == true) {
					Debug.Log ("Destroying Closed Door: " + this.gameObject.name);
					Destroy (this.gameObject);
				}
			}
		}
	}
}
