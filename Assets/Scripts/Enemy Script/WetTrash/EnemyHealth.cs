using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;
    public GameObject deathEffect;
    public bool isDamaged;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        enemy = GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("kena piso");
        if (collision.CompareTag("Weapon") || collision.CompareTag("Bullet"))
        {
            audioManager.PlaySFX(audioManager.wetEnemyDeath);
            Instantiate(deathEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.original;
    }
}