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
    private GameManager gameManager;
    [SerializeField] private GameObject hitSound;
    [SerializeField] private GameObject deathSound;


    private void Start()
    {
        pointToMove = GameObject.Find("Point To Move");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            transform.position += (pointToMove.transform.position - transform.position).normalized * moveSpeed * Time.fixedDeltaTime;
        }
        

        if (!gameManager.isGameActive)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<AudioSource>().Pause();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyHitPoints--;
            hitSound.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            if (enemyHitPoints <= 0)
            {
                GetComponent<AudioSource>().Pause();
                transform.position = new Vector3(100f, -6f, 0f);
                Invoke("DestroyObject", 1f);
                gameManager.UpdateScore(100);
                deathSound.GetComponent<AudioSource>().Play();
            }
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}