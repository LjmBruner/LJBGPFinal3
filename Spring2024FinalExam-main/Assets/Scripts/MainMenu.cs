using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text name;
    public InputField nameInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scoring.playerName = nameInput.text;
        name.text = Scoring.playerName;
    }

    public void ShowGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
