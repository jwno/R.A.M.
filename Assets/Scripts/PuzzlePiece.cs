using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour {
    public GameObject puzzle;
    int number;
	// Use this for initialization
	void Start () {
        string name = puzzle.name;
        char p = name[name.Length - 1];
        number = int.Parse(p.ToString());
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_0")
        {
            PlayerPrefs.SetInt("PUZZLE", number);
            Debug.Log("PUZZLE: " + number);
            Destroy(gameObject);
        }
    }
}
