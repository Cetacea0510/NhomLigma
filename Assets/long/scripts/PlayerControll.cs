using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    public GameObject bulletPrefabs;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        

        UpdateAnimationState();

        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }

    void UpdateAnimationState()
    {
        if (moveInput.x > 0)
        {
            animator.SetBool("isRunningRight", true);
            animator.SetBool("isRunningUp", false);
            animator.SetBool("isRunningLeft", false);
        }
        else if (moveInput.x < 0)
        {
            animator.SetBool("isRunningRight", false);
            animator.SetBool("isRunningUp", false);
            animator.SetBool("isRunningLeft", true);
        }
        else if (moveInput.y > 0)
        {
            animator.SetBool("isRunningRight", false);
            animator.SetBool("isRunningUp", true);
            animator.SetBool("isRunningLeft", false);
        }
        else if (moveInput.magnitude == 0) // Kiểm tra xem moveInput có vector rỗng (không di chuyển) không
        {
            animator.SetBool("isRunningRight", false);
            animator.SetBool("isRunningUp", false);
            animator.SetBool("isRunningLeft", false);
        }
    }

        void Shoot()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - firePoint.position.x, mousePos.y - firePoint.position.y);
        direction.Normalize();

        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        
    }

}
