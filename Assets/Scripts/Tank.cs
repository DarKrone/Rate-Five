using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private int enemyHitPoints = 3;
    private GameObject pointToMove;
    [SerializeField] private float moveSpeed = 1f;
    public GameManager gameManager;

    private void Start()
    {
        pointToMove = GameObject.Find("Point To Move");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        transform.position += (pointToMove.transform.position - transform.position).normalized * moveSpeed * Time.fixedDeltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyHitPoints--;
            Destroy(collision.gameObject);
            if (enemyHitPoints <= 0)
            {
                Destroy(gameObject);
                gameManager.UpdateScore(100);
            }
        }
    }

}
