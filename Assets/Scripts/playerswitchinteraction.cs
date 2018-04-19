using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerswitchinteraction : MonoBehaviour {

	List<Collider2D> inColliders = new List<Collider2D>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			inColliders.ForEach(n => n.SendMessage("Use",SendMessageOptions.DontRequireReceiver));
		}
	}

	bool OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.CompareTag("Switch"))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		inColliders.Add(col);
	}
	void OnTriggerExit2D(Collider2D col)
	{
		inColliders.Remove(col);
	}
}
