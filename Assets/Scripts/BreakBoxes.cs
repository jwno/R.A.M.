using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBoxes : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.transform.CompareTag("Player_1")){
			if (collider.gameObject.GetComponent<Player_1>().throwPlayer == true) {
				if (this.gameObject.name.Contains("Box")){
					Destroy (this.gameObject);
				}
			}
		}
	}

}
