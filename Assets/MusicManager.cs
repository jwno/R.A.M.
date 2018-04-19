using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip[] music;
    public string hello;

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
    void Update()
    {

    }

    public void ChangeBGM()
    {
        BGM.Stop();
        if (BGM.clip.name == music[0].name)
        {
            BGM.clip = music[0];
        }
        else
        {
            BGM.clip = music[1];
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
