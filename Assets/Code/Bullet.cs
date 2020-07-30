using System;

using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    public int damage = 40;
    public string bulletdirection = "default";

    public Rigidbody2D rb;

    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        switch (bulletdirection)
        {
            case "default":
                rb.velocity = transform.right * speed * 1.5F;
                break;
            case "diagonaltop":
                rb.velocity = new Vector3(speed,speed/2,0);
                break;
            case "diagonalbot":
                rb.velocity = new Vector3(speed,-speed/2,0);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
    }
}
