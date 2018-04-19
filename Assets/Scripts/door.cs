using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
	public bool isOpen;

	private Collider2D myCollider;
	/*private Vector3 posB;

	[SerializeField]
	private Transform transformB;	*/

	void Start()
	{
		myCollider = GetComponent<Collider2D>();
	}
	public void Open()
	{
		if(!isOpen)
		{
			SetState(true);
		}
	}
	
	public void Close()
	{
		if(isOpen)
		{
			SetState(false);
		}
	}

	public void Toggle()
	{
		if(isOpen)
		{
			Close();
		}
		else
		{
			Open();
		}
	}

	void SetState(bool open)
	{
		isOpen = open;
		myCollider.isTrigger = open;
		/*(GetComponent<RectTransform>().pivot = new Vector2(posB.x,posB.y);*/
	}
}
