using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public AudioClip newTrack;

    private AudioManager theAM;
	// Use this for initialization
	void Start () {
        theAM = FindObjectOfType<AudioManager>();

        if (newTrack != null)
            theAM.ChangeBGM();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
