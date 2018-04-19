using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(Button))]
public class Mute_Sprite : MonoBehaviour
{
    public Sprite Muted_Sprite;
    public Sprite UnMuted_Sprite;

    private Button button;

    void Start()
    {
        button = FindObjectOfType<Button>();
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<Mute_Sprite>().Length > 1)
        {
            Debug.Log("DESTROY");
            Destroy(gameObject);
        }
        
    }

    public void mute_s()
    {
        button.image.overrideSprite = Muted_Sprite;
    }

    public void unmute_s()
    {
        button.image.overrideSprite = UnMuted_Sprite;
    }
}
