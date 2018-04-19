using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.name == "Player_0") {
			Debug.Log ("Store This" + this.gameObject.name);
			GameVariables.key_dict[this.gameObject.name] = true;
			Destroy (this.gameObject);
		}
	}
}
