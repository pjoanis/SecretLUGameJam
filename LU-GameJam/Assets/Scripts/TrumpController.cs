using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {
    private int direction = -1;
    private int speed = 5;
    private Rigidbody2D rb2d;
    public Transform explosion;
    public Transform projectileTransform;
    private float lastShotTime;
    public Transform player;
    private int health = 50;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        lastShotTime = Time.time;
    }

    void FixedUpdate()
    {
        double firingTime = 1.0;
        Vector2 movement = new Vector2(1, 0);        
        rb2d.velocity = movement * speed * direction;

        if (Time.time > (firingTime + lastShotTime))
        {
            // get normalized shooting direction
            Vector2 shootingDirection = new Vector2(player.position.x - transform.position.x, player.position.y-transform.position.y);
            shootingDirection.Normalize();
            Fire(shootingDirection);
            lastShotTime = Time.time;
        }

    }
    void Fire(Vector2 shootingDirection)
    {
        float bulletSpeed = 10;
        Rigidbody2D projectile = projectileTransform.GetComponent<Rigidbody2D>();
        Rigidbody2D instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);
        instantiatedProjectile.velocity = shootingDirection * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.gameObject.CompareTag("Player"))
        {
            direction *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 1;
            if (health <= 0)
            {
                for (int n = 0; n < 10; n++)
                {
                    Instantiate(explosion, new Vector3(transform.position.x + Random.Range(-10.0f,10.0f), transform.position.y + Random.Range(-10.0f, 10.0f), 0), transform.rotation);
                }
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
