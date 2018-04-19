using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

	private Rigidbody2D rb2d;
	private BoxCollider2D bcollider;

	public float fallDelay;

	public float respawnDelay;

	private bool isFalling = false;

	private Vector2 initialposition; 

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		bcollider = GetComponent<BoxCollider2D>();
		initialposition = transform.position;
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.collider.CompareTag("Player"))
		{
			StartCoroutine(Fall());
		}
	}
	IEnumerator Fall()
	{
		yield return new WaitForSeconds(fallDelay);
		rb2d.bodyType= RigidbodyType2D.Dynamic;
		GetComponent<Collider2D>().isTrigger = true;
		isFalling = true;
		respawn();
		yield return 0;

	}

	void respawn()
	{
		StartCoroutine(respawnco());
	}

    IEnumerator respawnco()
    {
        yield return new WaitForSeconds(respawnDelay);
		isFalling = false;
		rb2d.bodyType = RigidbodyType2D.Kinematic;
		bcollider.isTrigger = false;
		transform.position = initialposition;
		rb2d.velocity = Vector2.zero;
    }
}
