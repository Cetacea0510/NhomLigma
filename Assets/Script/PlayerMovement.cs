using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    /*[SerializeField] private float moveSpeed = 5f;
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
        }
        Destroy(gameObject, 1.4f);
    }*/

    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;

    public float maxHealth = 100;
    public float currentHealth;

    public Image hpImage;
    public Image hpDelayImage;
    public float hurtSpeed = 0.5f;

    public AudioSource footstepsSound;
    public AudioClip gameOverAudio;

    //========
    public GameObject gameOverUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }

        hpImage.fillAmount = currentHealth / maxHealth;
        if (hpDelayImage.fillAmount > hpImage.fillAmount)
        {
            hpDelayImage.fillAmount -= hurtSpeed;
        }
        else
        {
            hpDelayImage.fillAmount = hpImage.fillAmount;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        anim.SetFloat("InputX", moveInput.x);
        anim.SetFloat("InputY", moveInput.y);

        if (context.canceled)
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("LastInputX", moveInput.x);
            anim.SetFloat("LastInputY", moveInput.y);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            AudioManager.instance.PlaySound(gameOverAudio);
            gameOverUI.SetActive(true);
        }
        Destroy(gameObject, 1.4f);
    }
}