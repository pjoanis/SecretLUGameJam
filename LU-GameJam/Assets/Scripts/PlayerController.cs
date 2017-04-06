using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{    
    // player rigidbody	
    private Rigidbody2D rb2d;
    // player animator
    private Animator animator;
    // player spriterenderer
    private SpriteRenderer spriteRenderer;
    // used to store when player last shot
    private float lastShotTime;
    // player health
    private int health = 3;
    // used to store when player was last hit
    private float lastHit;
    // get the textbox's script to call functions
    public TextStuff textScript;
    // on death explosion
    public Transform explosion;
    // bullet prefab (set in the scene)
    public Rigidbody2D projectile;
    // walking speed
    public float walkingSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastShotTime = Time.time;
        lastHit = Time.time;        
        textScript.SetHealthText(health);
    }

    void Update()
    {
        // minimum time between shots in seconds
        double firingTime = 0.3;
        float shootHorizontal = Input.GetAxis("Fire1");
        float shootVertical = Input.GetAxis("Fire2");

        if (Mathf.Abs(shootHorizontal) > 0.1 || Mathf.Abs(shootVertical) > 0.1)
        {
            if (Time.time > (firingTime + lastShotTime))
            {
                // get normalized shooting direction
                Vector2 shootingDirection = new Vector2(shootHorizontal, shootVertical);
                shootingDirection.Normalize();
                Fire(shootingDirection);
                lastShotTime = Time.time;
            }
        }


    }
    void Fire(Vector2 shootingDirection)
    {
        float bulletSpeed = 10;
        Rigidbody2D instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);
        instantiatedProjectile.velocity = shootingDirection * bulletSpeed;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * walkingSpeed;
        // direction: 0->idle, 1->down, 2->right, 3->up, 4->left
        int direction;
        int previousDirection = animator.GetInteger("Direction");
        if (moveHorizontal == 0 && moveVertical == 0)
            direction = 0;
        else if (Mathf.Abs(moveHorizontal) > Mathf.Abs(moveVertical))
        {
            if (moveHorizontal > 0)
                direction = 2;

            else
                direction = 4;
        }
        else
        {
            if (moveVertical > 0)
                direction = 3;
            else
                direction = 1;
        }
        if (direction == 2)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
        // previous direction is used by animator so animations don't restart if
        // preivousdirection == current direction (may rework this with a better solution)
        animator.SetInteger("PreviousDirection", previousDirection);
        animator.SetInteger("Direction", direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // seconds between hits
            int invincibleTime = 3;
            if (Time.time > (lastHit + invincibleTime))
            {
                health -= 1;
                // set the UI health text
                textScript.SetHealthText(health);
                // death condition
                if (health <= 0)
                {
                    //turn off this sprite & animator
                    this.spriteRenderer.enabled = false;
                    this.animator.enabled = false;
                    // explosion animation
                    Instantiate(explosion, transform.position, transform.rotation);
                    // destroy all other objects in game (don't think this is currently working)
                    Object[] allObjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
                    foreach (Object item in allObjects)
                    {
                        Destroy(item);
                    }

                }
                else
                {
                    // flash the player                    
                }
                lastHit = Time.time;
            }
        }
    }


}
