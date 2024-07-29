using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Enemy_Controllers : MonoBehaviour
{
    private float speed = 2f;
    private int facingDirection = 1;
    private EnemyState enemyState;

    private Rigidbody2D rb;
    public Transform player;
    public Animator anim;

    bool isAlive = true;
    public float Health
    {
        set
        {
            if (value < _health)
            {
                anim.SetTrigger("hit");
            }

            _health = value;


            if (value <= 0)
            {
                anim.SetBool("isAlive", false);
                ScoreManager.instance.AddPoint();
                Destroy(gameObject, 1);
            }
        }
        get
        {
            return _health;
        }
    }

    public float _health = 3;

    public Transform attackPoint;
    public LayerMask playerLayers;

    public float attackRange = 0.95f;
    public int attackDamage = 20;

    //thoi gian tan cong
    private float attackRate = 1f;//1
    float nextAttackTime = 0f;//0
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isAlive", isAlive);
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyState.Chasing)
        {
            if (player.position.x > transform.position.x && facingDirection == -1 ||
                 player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();
            }
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;

            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 2f / attackRate;
            }
        }
    }

    void OnHit(float damage)
    {
        Health -= damage;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
            ChangeState(EnemyState.Chasing);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            OnHit(1);
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
            player.GetComponent<demoplayerWenemy>().TakeDamage(attackDamage);
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
public enum EnemyState
{
    Idle,
    Chasing,
}