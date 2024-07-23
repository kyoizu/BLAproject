using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firingPoint;
    public bool canFire;
    private float timer;
    public float fireRate;
    public GameObject bulletPrefab;
    EnemyMovement enemyMov;
    void Start()
    {
        enemyMov = gameObject.GetComponent<EnemyMovement>();
    }
    void Update()
    {
        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > fireRate)
            {
                canFire = true;
                timer = 0;
            }
        }
        if(canFire)
        {
            Shoot();
            canFire = false;
        }
    }
    void Shoot()
    {
        float angle = enemyMov.movingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
