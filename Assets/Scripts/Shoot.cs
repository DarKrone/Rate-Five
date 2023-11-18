using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject aimPoint;
    [SerializeField] private Camera mainCamera;
    private AudioSource audioSource;
    [SerializeField] private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() // проверка что нажата кнопка выстрела
    {
        if (Input.GetMouseButtonDown(0) && gameManager.GetComponent<GameManager>().isGameActive)
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0f;
            Vector2 dir = mouseWorldPosition - transform.position;
            Fire(dir);

        }
    }

    private void Fire(Vector2 dir) // функция выстрела
    {
        audioSource.Play();
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.parent = transform.parent;
        bullet.transform.position = aimPoint.transform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = dir;
    }
}
