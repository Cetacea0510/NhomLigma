using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Boss_Controllers Boss;
  
    //=============
    public GameObject bulletPrefabs;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime;
    [SerializeField] public AudioClip fireArrow;

    void Update()
    {
        RotateBow();

        if (Input.GetMouseButton(1) && Time.time >= nextFireTime)
        {
            FireArrow();
            nextFireTime = Time.time + fireRate;
        }

    }
    void RotateBow()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

    }

    void FireArrow()
    {
        //timeAtwFire = TimeAtwFire;

        //GameObject arrowTmp = Instantiate(arrow, firePos.position, Quaternion.identity);

        //Rigidbody2D rb = arrowTmp.GetComponent<Rigidbody2D>();
        //rb.AddForce(transform.right * arrowForce, ForceMode2D.Impulse);
        //===
        AudioManager.instance.PlaySound(fireArrow);
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - firePoint.position.x, mousePos.y - firePoint.position.y);
        direction.Normalize();

        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

   
    }

}