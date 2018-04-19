using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_platform : MonoBehaviour {

	public bool isOpen;

	private Collider2D myCollider;

	 private GameObject platform;
	/*private Vector3 posB;

	[SerializeField]
	private Transform transformB;	*/
	
    public static bool canMove = false;

    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nexPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

	// Use this for initialization
	void Start () {
        posB = transformB.localPosition;
        posA = childTransform.localPosition;
        nexPos = posB;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}
    private void Move()
    {
		if(canMove)
		{
            childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);
            if( Vector3.Distance(childTransform.localPosition, nexPos) <= 0.01)
            {
                ChangeDestination();
            }
		}
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
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
		canMove = true;
		
	}

}
