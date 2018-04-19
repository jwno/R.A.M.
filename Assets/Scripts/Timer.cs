using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	public Text timerText;
	public float startTime;

	private float start;
	// Use this for initialization
	void Start () {
		start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		float t = startTime-Time.time;

		string minutes = ((int)t/60).ToString();
		string seconds = (t % 60).ToString("f2");

		timerText.text = minutes + ": " +seconds;
		if(t<0){
			Die();
		}
	}

    void Die()
    {
        SceneManager.LoadScene("Level 4");
    }
}
