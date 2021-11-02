using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    public int pointsOnPlayerDestruction;
    public bool isSplitter = false;

    Enemies _enemies;
    Score score;
    Collectables collectables;
    void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        collectables = GameObject.FindGameObjectWithTag("Collectables").GetComponent<Collectables>();
        
        GameObject gaObj = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        _enemies = gaObj.GetComponent<Enemies>();
    }

    public void DestroyByPlayer()
    {
        Debug.Log("Destroyed By the Player");

        _enemies.currentEnemiesAmount--;
        score.IncreaseScore(pointsOnPlayerDestruction);
        collectables.SpawnRandomCollectable(transform);
        Destroy(gameObject);
    }

    
}
