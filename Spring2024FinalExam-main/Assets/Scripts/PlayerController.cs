using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody sphere;

    public float moveSpeed;

    private bool isPaused;

    public Text pauseText;
    
    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponent<Rigidbody>();
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            sphere.velocity = new Vector3(-1 * moveSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            sphere.velocity = new Vector3(1 * moveSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            sphere.velocity = new Vector3(0, 0, 1 * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            sphere.velocity = new Vector3(0, 0, -1 * moveSpeed);
        }
        else
        {
            sphere.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                isPaused = true;
            }
            else
            {
                isPaused = false;
            }
        }

        if (isPaused)
        {
            sphere.Sleep();
            pauseText.text = "PAUSED";
        }
        else
        {
            sphere.WakeUp();
            pauseText.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            Scoring.score++;
            Destroy(other.gameObject);
        }
    }
}
