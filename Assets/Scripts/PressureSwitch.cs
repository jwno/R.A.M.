using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : Switch {
	public Sprite red;

    public Sprite green;

    SpriteRenderer doorSwitch;

	public int numberColliding = 0;
	void Start()
	{
		SpriteRenderer doorSwitch = GameObject.Find("Switch").GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		numberColliding++;
		TurnOn();
		doorSwitch.sprite = green;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		numberColliding--;
		if(numberColliding == 0)
		{
			TurnOff();
			doorSwitch.sprite = red;

		}
	}
}
