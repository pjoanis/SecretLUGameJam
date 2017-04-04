using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStuff : MonoBehaviour {

    public Text healthText;
    public Text countKillsText;
    

    private Rigidbody rb;
    private int countKills = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetKillText(int countKills)
    {
        countKillsText.text = "Kills: " + countKills.ToString();
        if (countKills >= 10)
        {
            
        }
    }

    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
           
        }
    }
}
