﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Boss_Controllers : MonoBehaviour
{
    public GameObject globalLight;
    public GameObject currentLight;
    public GameObject congratObject;
 
    private float speed = 2f;
    private int facingDirection = 1;
    private EnemyState enemyState;

    private Rigidbody2D rb;
    public Transform player;
    public Animator anim;

    bool isAlive = true;

    public float _health = 15;

    public Transform attackPoint;
    public LayerMask playerLayers;

    private float attackRange = 0.95f;
    public int attackDamage = 25;

    //thoi gian tan cong
    private float attackRate = 2f;//2
    float nextAttackTime = 0f;//0
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isAlive", isAlive);
        ChangeState(EnemyState.Idle);
        //==
        congratObject.SetActive(false);
        globalLight.SetActive(true);
        currentLight.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyState.Chasing && player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;

            if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();
            }

            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 4f / attackRate;
            }
        }
        
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        anim.SetTrigger("hit");

        if (_health <= 0)
        {
            globalLight.SetActive(false);
            currentLight.SetActive(false);
            rb.velocity = Vector2.zero;
            anim.SetBool("isAlive", false);
            Destroy(gameObject, 1.2f);
            congratObject.SetActive(true);
           
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform;
            ChangeState(EnemyState.Chasing);
        }

    }
    
    void Attack()
    {
        //play an animation 
        anim.SetTrigger("Attack");
        //enemy in range in attack
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        //damage them 
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
        }


    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }
    void ChangeState(EnemyState newState)
    {
        //exit the current animation
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", false);
        //update our current state
        enemyState = newState;
        //update the new animation
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", true);
    }

}