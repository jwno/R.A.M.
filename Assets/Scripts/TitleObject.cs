using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleObject : MonoBehaviour {
    public List<Sprite> imageList;
    Image title;
    Image titleAnim;
	// Use this for initialization
    void Start()
    {
        title = GameObject.Find("Title").GetComponent<Image>();
        titleAnim = GameObject.Find("TitleAnimation").GetComponent<Image>();

        if (!PlayerPrefs.HasKey("PUZZLE"))
            PlayerPrefs.SetInt("PUZZLE", 0);

        int puzzle = PlayerPrefs.GetInt("PUZZLE");
        if (puzzle == 4)
        {
            title.enabled = false;
            titleAnim.enabled = true;
        }
        else
        {
            title.sprite = imageList[puzzle];
            title.enabled = true;
            titleAnim.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
