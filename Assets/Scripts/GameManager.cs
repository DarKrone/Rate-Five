using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject leftSpawnPos;
    [SerializeField] private GameObject rightSpawnPos;
    [SerializeField] private GameObject tankPrefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] public bool isGameActive = true;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Buildings buildings;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int score = 0;


    private void Start()
    {
        StartCoroutine(SpawnTarget());
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        if(buildings.hitPoints <= 0) // остановка игры если проиграли
        {
            isGameActive= false;
            gameOverUI.SetActive(true);
        }

        if (!isGameActive)
        {
            buildings.GetComponent<AudioSource>().Pause();
        }
    }
    IEnumerator SpawnTarget() // спавним врагов каждое определенное количество времени
    {
        while (isGameActive) 
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject tank = Instantiate(tankPrefab);
            int side = UnityEngine.Random.Range(0, 100);
            if(side < 50)
            {
                tank.transform.position = leftSpawnPos.transform.position;
            }
            else
            {
                tank.transform.position = rightSpawnPos.transform.position;
                tank.transform.localScale = new Vector3(tank.transform.localScale.x * -1, tank.transform.localScale.y, tank.transform.localScale.z);
                var healthBar = tank.transform.GetChild(2);
                healthBar.localScale = new Vector3(healthBar.transform.localScale.x * -1, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            }
        }

    }

    public void UpdateScore(int value) // обновляем счёт
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void Quit() // выход из игры
    {
        Application.Quit();
    }
}
