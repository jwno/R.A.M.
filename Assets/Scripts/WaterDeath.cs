using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour {
	GameObject death;
	Character_Move p0;
	// Use this for initialization
	void Start () {
		death = GameObject.Find ("DeathLocation").GetComponent<GameObject> ();
		p0 = GameObject.Find ("Player_0").GetComponent<Character_Move> ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		p0.transform.position = death.transform.position;
	}
}
