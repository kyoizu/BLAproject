using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Camera maincCam;
    public Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        maincCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void FixedUpdate() 
    {
        rb.velocity = transform.right * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit enemy!");
            DestroyBullet();
        }
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("Bullet hit player!");
            GetComponent<BoxCollider2D>().isTrigger = true;

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
