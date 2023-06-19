using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    [SerializeField] public int hitPoints = 3;
    private GameManager gameManager;
    public GameObject hitSound;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hitPoints -= 1;
            Destroy(collision.gameObject);
            gameManager.UpdateScore(-500);
            hitSound.GetComponent<AudioSource>().Play();
        }
    }
}
