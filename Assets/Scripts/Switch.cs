using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public enum ResetType {Never, OnUse, Timed, Immediately}

    public ResetType resetType= ResetType.OnUse;
    public GameObject Target;

    public string onMessage;

    public string offMessage;

    public bool isOn;

    public float ResetTime;

    
    Animator myAnimator;
    // Use this for initialization
    void Start()
    {
        // myAnimator = GetComponent<Animator>();
    }

    public void TurnOn()
    {
        if (!isOn)
        {
            SetState(true);
        }

    }

    public void TurnOff()
    {
        if(isOn && resetType != ResetType.Never && resetType != ResetType.Timed)
        {
            SetState(false);
        }
    }

    public void Toggle()
    {
        if(isOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    void TimedReset()
    {
        SetState(false);
    }
    void SetState(bool on)
    {
        isOn = on;
        // myAnimator.SetBool("On",on);
        Sprite onSwitch = Resources.Load("Switch(2)",typeof(Sprite)) as Sprite;
        if(on)
        {
            if(Target!= null && !string.IsNullOrEmpty(onMessage))
            {
                Target.SendMessage(onMessage);
                
            }
            if(resetType == ResetType.Immediately)
            {
                TurnOff();
            }
            else if(resetType == ResetType.Timed)
            {
                Invoke("TurnReset",ResetTime);
            }
        }
        else
        {
             if(Target!= null && !string.IsNullOrEmpty(offMessage))
            {
                Target.SendMessage(offMessage);
            } 
        }
    }
    
}
