using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Button : MonoBehaviour {
    public Sprite Mute;
    public Sprite UnMute;
    private Button BGM_Button;
    private Button SFX_Button;
    AudioSource audio;

    void Awake() 
    {
        BGM_Button = GameObject.Find("BGM_Button").GetComponent<Button>();
        SFX_Button = GameObject.Find("SFX_Button").GetComponent<Button>();
        audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("BGM"))
            PlayerPrefs.SetString("BGM", "TRUE");
        if (!PlayerPrefs.HasKey("SFX"))
            PlayerPrefs.SetString("SFX", "TRUE");
    }

    void Start()
    {
        if (PlayerPrefs.GetString("BGM") == "TRUE")
        {
            BGM_Button.image.overrideSprite = UnMute;
            audio.mute = false;
        }
        else
        {
            BGM_Button.image.overrideSprite = Mute;
            audio.mute = true;
        }

        if (PlayerPrefs.GetString("SFX") == "TRUE")
        {
            SFX_Button.image.overrideSprite = UnMute;
        }
        else
        {
            SFX_Button.image.overrideSprite = Mute;    
        }
    }
    public void BGM_Mute_Button()
    {
        if (PlayerPrefs.GetString("BGM") == "FALSE")
        {
            Debug.Log("FALSE");
            BGM_Button.image.overrideSprite = UnMute;
            audio.mute = false;
            PlayerPrefs.SetString("BGM", "TRUE");
        }
        else
        {
            Debug.Log("TRUE");
            BGM_Button.image.overrideSprite = Mute;
            audio.mute = true;
            PlayerPrefs.SetString("BGM", "FALSE");
        }
    }

    public void SFX_Mute_Button()
    {
        if (PlayerPrefs.GetString("SFX") == "FALSE")
        {
            SFX_Button.image.overrideSprite = UnMute;
            PlayerPrefs.SetString("SFX", "TRUE");
        }
        else
        {
            SFX_Button.image.overrideSprite = Mute;
            PlayerPrefs.SetString("SFX", "FALSE");
        }
    }
}
