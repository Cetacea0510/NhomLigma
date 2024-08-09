using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScrip : MonoBehaviour
{
    public int damage = 10;
    public float speed = 9f;
    private Rigidbody2D rb;
    Boss_Controllers Boss;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;


        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Collider2D playerCollider = player.GetComponent<Collider2D>();
            Collider2D arrowCollider = GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(arrowCollider, playerCollider);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Boss_Controllers enemy = collision.gameObject.GetComponent<Boss_Controllers>();
        //if (enemy != null)
        //{
        //    enemy.TakeDamage(1);
        //    Destroy(gameObject); // Phá hủy mũi tên sau khi trúng mục tiêu
        //}
        //else if (!collision.gameObject.CompareTag("Player"))
        //{
        //    Destroy(gameObject); // Phá hủy mũi tên nếu không va chạm với quái vật và không phải là người chơi
        //}

        // Kiểm tra và gây sát thương cho các loại quái vật khác nhau
        Boss_Controllers boss = collision.gameObject.GetComponent<Boss_Controllers>();
        Enemy_Controllers enemy = collision.gameObject.GetComponent<Enemy_Controllers>();
        Slime_Controller slime = collision.gameObject.GetComponent<Slime_Controller>();

        if (boss != null)
        {
            boss.TakeDamage(1.2f);
            Destroy(gameObject); // Phá hủy mũi tên sau khi trúng quái vật
        }
        else if (enemy != null)
        {
            enemy.TakeDamage(1);
            Destroy(gameObject); // Phá hủy mũi tên sau khi trúng quái vật
        }
        else if (slime != null)
        {
            slime.TakeDamage(1);
            Destroy(gameObject); // Phá hủy mũi tên sau khi trúng quái vật
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Phá hủy mũi tên nếu va chạm với bất kỳ thứ gì khác không phải quái vật hoặc người chơi
        }
    }

}