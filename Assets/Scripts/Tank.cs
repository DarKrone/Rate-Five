using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    [SerializeField] private int enemyHitPoints = 3;
    private int maxHP;
    private GameObject pointToMove;
    [SerializeField] private float moveSpeed = 1f;
    private GameManager gameManager;
    [SerializeField] private GameObject hitSound;
    [SerializeField] private GameObject deathSound;
    [SerializeField] private Image hpBar;


    private void Start()
    {
        maxHP = enemyHitPoints;
        pointToMove = GameObject.Find("Point To Move");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            transform.position += (pointToMove.transform.position - transform.position).normalized * moveSpeed * Time.fixedDeltaTime;
        }
        else
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
            ChangeHPBar();
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

    void ChangeHPBar()
    {
        hpBar.GetComponent<Image>().fillAmount = (float)enemyHitPoints / (float)maxHP;
    }
}
