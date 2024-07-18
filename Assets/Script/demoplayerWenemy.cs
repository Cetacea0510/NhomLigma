using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demoplayerWenemy : MonoBehaviour
{
    private float speed = 5f;
    public int facingDirection = 1;

    public Rigidbody2D rb;

    public float maxHealth = 100;
    public float cunrrentHealth;

    public Image hpImage;
    public Image hpDelayImage;
    public float hurtSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cunrrentHealth = maxHealth;
    }

    public void Update()
    {
        hpImage.fillAmount = cunrrentHealth / maxHealth;
        if (hpDelayImage.fillAmount > hpImage.fillAmount)
        {
            hpDelayImage.fillAmount -= hurtSpeed;
        }
        else
        {
            hpDelayImage.fillAmount = hpImage.fillAmount;
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
        rb.velocity = new Vector2(horizontal, vertical) * speed;
    }


    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}