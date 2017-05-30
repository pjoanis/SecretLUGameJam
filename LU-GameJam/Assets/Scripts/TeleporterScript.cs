using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour {
    private bool _isPlayerOverlapping = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_isPlayerOverlapping)
        {
            // if key pressed && player overlapping, load the level
            SceneManager.LoadScene("GameJam");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            _isPlayerOverlapping = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerOverlapping = false;
        }
    }
}
