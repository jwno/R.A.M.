using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartNew : MonoBehaviour
{
    Transition_Scene transition;
    GameObject panel;
    Button playButton;
    Button backButton;
    void Start()
    {
        transition = FindObjectOfType<Transition_Scene>();

        panel = GameObject.Find("Start_Panel");
        playButton = GameObject.Find("Play_Button").GetComponent<Button>();
        backButton = GameObject.Find("Back_Button").GetComponent<Button>();
        panel.SetActive(false);
    }
    public void StartNewButton()
    {
        if (PlayerPrefs.HasKey("LEVEL"))
        {
            panel.SetActive(true);
            playButton.onClick.AddListener(playPressed);
            backButton.onClick.AddListener(backPressed);
        } else
        {
            transition.load("Level_0");
            PlayerPrefs.SetInt("LEVEL", 0);
            PlayerPrefs.SetInt("PUZZLE", 0);
        }
    }

    void playPressed()
    {
        panel.SetActive(false);
        transition.load("Level_0");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LEVEL", 0);
        PlayerPrefs.SetInt("PUZZLE", 0);
    }

    void backPressed()
    {
        panel.SetActive(false);
    }
}
