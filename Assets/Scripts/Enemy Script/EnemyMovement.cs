using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float moveRange;

    private Vector3 leftPoint;
    private Vector3 rightPoint;
    public bool movingRight = true;
    
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        leftPoint = transform.position + new Vector3(moveRange, 0f, 0f);
        rightPoint = transform.position - new Vector3(moveRange, 0f, 0f);
        anim.SetBool("Nwalk", false);
        if(moveRange != 0)
        {
            StartCoroutine(MoveEnemy());
        }
    }

    

    private IEnumerator MoveEnemy()
    {
        while (true)
        {
            anim.SetBool("Nwalk", true);
            if (movingRight)
            {
                // Move towards the right point
                transform.position = Vector3.MoveTowards(transform.position, rightPoint, moveSpeed * Time.deltaTime);
                transform.localScale = new Vector3(1f, 1f, 1f);

                // Check if the enemy has reached the right point
                if (transform.position == rightPoint)
                    movingRight = false;
            }
            else
            {
                // Move towards the left point
                transform.position = Vector3.MoveTowards(transform.position, leftPoint, moveSpeed * Time.deltaTime);
                transform.localScale = new Vector3(-1f, 1f, 1f);

                // Check if the enemy has reached the left point
                if (transform.position == leftPoint)
                    movingRight = true;
            }
            yield return null;
        }
    }
}
