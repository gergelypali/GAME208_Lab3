using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
// main class for the enemy
public class Enemy : MonoBehaviour
{
    public Rigidbody rb;

    // these are used during instantiation
    public int spawnTime;
    public float yOffset;

    // damage and death part
    public float health;
    public float damageTaken;

    // animator to control the model
    Animator animator;

    public virtual void Attack()
    {
        //Base Method for attacking
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.applyRootMotion = false;
        }
        // check for input parameters
        if (spawnTime <= 0)
        {
            Debug.Log("Using default spawnTime; 1 sec!");
            spawnTime = 1;
        }
        if (yOffset <= 0)
        {
            Debug.Log("Using default yOffset; 0.5f!");
            yOffset = 0.5f;
        }
        if (health <= 0)
        {
            health = 100.0f;

            Debug.Log("Health not set. Defaulting to " + health);
        }
        if (damageTaken <= 0)
        {
            damageTaken = 25.0f;

            Debug.Log("DamageTaken not set. Defaulting to " + damageTaken);
        }
    }
    void Update()
    {
        // use key R to despawn every enemy from the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Despawn enemy!");
            DestroyEnemy();
        }
        // use key E to attack with every enemy on the scene
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Enemy attack!");
            Attack();
        }
    }
    // after collision with bullet, decrease the health and kill the enemy if below 0
    public void takedamage()
    {
        Debug.Log("Taking damage");
        health -= damageTaken;
        if (health < 1)
        {
            Debug.Log("Enemey died");
            animator.SetTrigger("Died");
        }
    }
    // check the collision of the bullet, enemy will take damage and destroy the bullet in this case
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnCollisionEnter: " + collision.gameObject.name);
        Debug.Log("OnCollisionEnter: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "bullet")
        {
            animator.SetTrigger("TakeDamage");
            Debug.Log("TakeDamage");
            Destroy(collision.gameObject);
        }
    }
}
