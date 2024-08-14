﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;

    public Image hpImage;
    public Image hpDelayImage;
    public float hurtSpeed = 0.5f;

    //===========
    public float maxHealth = 100;
    public float cunrrentHealth;

    //===========
    public AudioSource movementSound;
    [SerializeField ]public AudioClip gameOverSound;

    //==========
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cunrrentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput * moveSpeed;

        hpImage.fillAmount = cunrrentHealth / maxHealth;
        if (hpDelayImage.fillAmount > hpImage.fillAmount)
        {
            hpDelayImage.fillAmount -= hurtSpeed;
        }
        else
        {
            hpDelayImage.fillAmount = hpImage.fillAmount;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            movementSound.enabled = true;
        }
        else
        {
            movementSound.enabled = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        anim.SetBool("isWalking", true);

        if (context.canceled)
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
        /*//Debug.Log("Enemy died!");
        //die animation
        anim.SetBool("isDead", true);
        //disable the enemy
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1f);*/

        // Kích hoạt hoạt ảnh chết
        anim.SetBool("isDead", true);

        // Vô hiệu hóa script của player
        this.enabled = false;

        // Vô hiệu hóa collider để không có va chạm
        GetComponent<Collider2D>().enabled = false;

        // Vô hiệu hóa Rigidbody2D để ngăn trượt
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Đặt vận tốc về 0
            rb.isKinematic = true; // Đặt chế độ kinematic để ngăn tương tác vật lý
            gameOverPanel.SetActive(true);
            AudioManager.instance.PlaySound(gameOverSound);
        }
        Destroy(gameObject, 1.4f);
    }
}