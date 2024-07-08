using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoplayerWenemy : MonoBehaviour
{
    private float speed = 5f;
    public int facingDirection = 1;

    public Rigidbody2D rb;

    public int maxHealth = 100;
    public int cunrrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        cunrrentHealth = maxHealth;

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
        cunrrentHealth -= damage;
        //play hurt animation
        //animator.SetTrigger("Hurt");

        if (cunrrentHealth <= 0)
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

        if (horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        // Đảm bảo rằng rb đã được gán trước khi sử dụng
        if (rb != null)
        {
            rb.velocity = new Vector2(horizontal, vertical) * speed;
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
