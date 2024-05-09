using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Slider sizeSlider;
    public GameObject sphere;
    public Dropdown colorDropDown;
    public Text scoreText;
    public Text nameText;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Scoring.score.ToString();
        nameText.text = Scoring.playerName;
    }

    public void ShowExitScene()
    {
        SceneManager.LoadScene("Exit");
    }

    public void ChangeColor()
    {
        if (colorDropDown.value == 0)
        {
            sphere.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (colorDropDown.value == 1)
        {
            sphere.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            sphere.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void ChangeSize()
    {
        sphere.transform.localScale = new Vector3(sizeSlider.value, sizeSlider.value, sizeSlider.value);
    }
}