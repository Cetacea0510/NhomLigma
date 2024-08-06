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
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Boss_Controllers enemy = collision.gameObject.GetComponent<Boss_Controllers>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
            Destroy(gameObject); // Phá hủy mũi tên sau khi trúng mục tiêu
        }
        else
        {
            // Nếu va chạm với thứ khác không phải quái vật, phá hủy mũi tên
            Destroy(gameObject);
        }
    }

}