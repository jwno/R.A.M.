using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_In_Out : MonoBehaviour {
    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = 0;
    private float alpha = 1.0f;
    private float fadeDir = -1;


    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(float direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void Loaded()
    {
        BeginFade(-1);
    }
}
