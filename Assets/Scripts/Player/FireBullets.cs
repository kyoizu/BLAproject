using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    private Camera mainCam;
    public Transform firingPoint;
    public bool canFire;
    private float timer;
    public float fireRate;
    public GameObject bulletPrefab;
    AudioManager audioManager;
    PlayerController playerMov;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerMov = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
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

        if(Input.GetMouseButton(0) && canFire)
        {
            audioManager.PlaySFX(audioManager.playerAtkShot);
            Shoot();
            canFire = false;
        }
    }

    void Shoot()
    {
        float angle = playerMov.isFaceRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
