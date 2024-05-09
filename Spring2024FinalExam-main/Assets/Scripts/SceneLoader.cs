using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("CapsuleTarget") == null && GameObject.Find("CapsuleTarget (1)") == null && GameObject.Find("CapsuleTarget (2)") == null && GameObject.Find("CapsuleTarget (3)") == null && GameObject.Find("CapsuleTarget (4)") == null)
        {
            SceneManager.LoadScene("Exit");
        }
    }
}
