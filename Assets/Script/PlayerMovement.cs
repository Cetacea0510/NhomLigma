using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;

    //===========
    public float maxHealth = 100;
    public float cunrrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        anim.SetBool("isWalking", true);

        if(context.canceled)
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("LastInputX", moveInput.x);
            anim.SetFloat("LastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();
        anim.SetFloat("InputX", moveInput.x);
        anim.SetFloat("InputY", moveInput.y);
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
}
