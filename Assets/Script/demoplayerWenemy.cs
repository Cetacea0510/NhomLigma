using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoplayerWenemy : MonoBehaviour
{
    private float speed = 5f;
    public Rigidbody2D rb;

    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        // Kiểm tra và gán Rigidbody2D nếu chưa gán trong Inspector
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody2D component is missing from this game object!");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play hurt animation
        //animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Debug.Log("Enemy died!");
        //die animation
        //animator.SetBool("isDead", true);
        //disable the enemy
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.2f);
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        if (rb != null)
        {
            rb.velocity = movement * speed;
        }
    }
}
