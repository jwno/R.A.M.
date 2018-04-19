using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Exit : MonoBehaviour {
    public void quit()
    {
        Debug.Log("Quit Successful");
        Application.Quit();
    }
}
