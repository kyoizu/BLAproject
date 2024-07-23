using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force = 5;
    private void FixedUpdate() 
    {
        rb.velocity = transform.right * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Bullet hit player!");
            GetComponent<BoxCollider2D>().isTrigger = true;
            DestroyBullet();
        }
        else if (collision.CompareTag("Ground"))
        {
            Debug.Log("Bullet hit ground!");
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
            Destroy(gameObject);
    }
}
