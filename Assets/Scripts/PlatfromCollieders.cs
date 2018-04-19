using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromCollieders : MonoBehaviour {

    private BoxCollider2D playerCollider;

    [SerializeField]
    private BoxCollider2D platformCollider;

    [SerializeField]
    private BoxCollider2D platformTrigger;

	// Use this for initialization
	void Start () {
        playerCollider = GameObject.Find("Player_0").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
	}
	void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player_0")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        }
	}
}
