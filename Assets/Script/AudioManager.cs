using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    public AudioSource BGM;
    public AudioClip[] music;
    bool check = true;

	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		if (SceneManager.GetActiveScene().name == "HubWorld" && check)
        {
            ChangeBGM();
            check = false;
        } else if (SceneManager.GetActiveScene().name != "HubWorld" && !check)
        {
            ChangeBGM();
            check = true;
        }
	}

    public void ChangeBGM()
    {
        BGM.Stop();
        if (BGM.clip.name == music[0].name)
        {
            BGM.clip = music[1];
        } else
        {
            BGM.clip = music[0];
        }
        BGM.Play();
    }

    public void mute()
    {
        BGM.mute = true;
    }

    public void unmute()
    {
        BGM.mute = false;
    }
}
