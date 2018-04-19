using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
	[SerializeField]Transform spawn_point;

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.CompareTag ("Player_0")) {
			col.transform.position = spawn_point.position;
		}
		if (col.transform.CompareTag ("Player_1")) {
			col.transform.position = spawn_point.position;
		}

	}
}
