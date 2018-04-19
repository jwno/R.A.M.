using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Game : MonoBehaviour {
    Character_Move p0;
    public Transform canvas;
    public static bool pause;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
                Pause();
            else
                UnPause();
        }
    }

    public void Start()
    {
        pause = false;
        p0 = GameObject.Find("Player_0").GetComponent<Character_Move>();
        UnPause();
    }

    public void Pause()
    {
        canvas.gameObject.SetActive(true);
        p0.enabled = false;
        Time.timeScale = 0;
        Debug.Log("TRUE");
        pause = true;
    }

    public void UnPause()
    {
        canvas.gameObject.SetActive(false);
        p0.enabled = true;
        Time.timeScale = 1;
        pause = false;
    }
}
