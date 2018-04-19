using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Mute : MonoBehaviour
{
    public Sprite Muted_Sprite;
    public Sprite UnMuted_Sprite;
    //public Button button;

    private AudioManager audio;
    private bool mute_b;
    private Mute_Sprite button;

    void Start()
    {
        audio = FindObjectOfType<AudioManager>();
        button = FindObjectOfType<Mute_Sprite>();
        mute_b = false;
    }

    public void mute()
    {
        if (mute_b)
        {
            audio.unmute();
            button.unmute_s();
            //button.mute_s();
            //button.image.overrideSprite = UnMuted_Sprite;
            mute_b = false;
        }
        else
        {
            audio.mute();
            button.mute_s();
            //button.image.overrideSprite = Muted_Sprite;
            mute_b = true;
        }
    }
}
