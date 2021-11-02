using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public int bombAmount;
    public GameObject[] bombSprites;
    public GameObject enemiesGaOb;
    public GameObject bulletsGaOb;

    
    

    private void Start()
    {
        int startingNukesAmount = 5;
        bombAmount = startingNukesAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            print("Nuking");
            IgniteNuke();
        }
    }

    void IgniteNuke()
    {
        if (bombAmount > 0)
        {
            foreach (Transform enemy in enemiesGaOb.transform)
            {
                EnemyDestroyController enemyDestroyController = enemy.GetComponent<EnemyDestroyController>();
                enemyDestroyController.DestroyByPlayer();
            }
            foreach (Transform bullets in bulletsGaOb.transform)
            {
                Destroy(bullets.gameObject);
            }


            bombAmount--;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bombSprites.Length; i++)
        {
            if (i < bombAmount)
            {
                bombSprites[i].SetActive(true);
            }
            else
            {
                bombSprites[i].SetActive(false);
            }
        }
    }
}
