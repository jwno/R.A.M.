using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Transition_Scene : MonoBehaviour {
    public void load(string canvas)
    {
        StartCoroutine(fade(canvas));
    }

    IEnumerator fade(string canvas)
    {
        float fadeTime = GameObject.Find("Fade").GetComponent<Fade_In_Out>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(canvas);
    }
}
