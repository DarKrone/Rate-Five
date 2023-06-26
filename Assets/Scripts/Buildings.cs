using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buildings : MonoBehaviour
{
    [SerializeField] public int hitPoints = 3;
    private int maxHP;
    private GameManager gameManager;
    public GameObject hitSound;
    [SerializeField] private Image health;
    private void Start()
    {
        maxHP= hitPoints;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hitPoints -= 1;
            Destroy(collision.gameObject);
            ChangeHPBar();
            gameManager.UpdateScore(-500);
            hitSound.GetComponent<AudioSource>().Play();
        }
    }

    void ChangeHPBar()
    {
        health.GetComponent<Image>().fillAmount = (float)hitPoints / (float)maxHP;
    }
}
