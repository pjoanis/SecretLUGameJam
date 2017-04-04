using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public Transform player;
    private Rigidbody2D rb2d;
    public Transform textbox;
    private TextStuff textScript;
    public float movementSpeed;
    public Transform explosion;    
    private SpriteRenderer spriteRenderer;
    private static int killCount = 0;
    private static bool donaldSpawned = false;
    public Transform theDonald;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        textScript = textbox.GetComponent<TextStuff>();
        textScript.SetKillText(killCount);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Vector3 myPosition = rb2d.transform.position;
        Vector3 playerPosition = player.position;        
        Vector2 movement = new Vector2(playerPosition.x - myPosition.x, playerPosition.y - myPosition.y);
        if (movement.x>0)
            this.spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
        rb2d.velocity = movement * movementSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PlayerBullet")) 
        {
            killCount++;
            textScript.SetKillText(killCount);
            if (killCount >= 10 && !donaldSpawned)
            {
                Transform instantiatedDonald = Instantiate(theDonald, new Vector3(0, (float)7.68, 0), transform.rotation);
                TrumpController trumpScript = instantiatedDonald.GetComponent<TrumpController>();
                trumpScript.player = player;
                donaldSpawned = true;
            }
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
