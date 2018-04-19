using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateArrow : MonoBehaviour {
    public GameObject player_1;
    private float speed = 100f;
	
	// Update is called once per frame
	private void Update () {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion pRotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        if (Character_Move.state == 1 || Character_Move.state == 3)
            player_1.transform.rotation = Quaternion.Slerp(transform.rotation, pRotation, speed * Time.deltaTime);
        else
            player_1.transform.rotation = Quaternion.Euler(0, 0, 0);
	}
}
