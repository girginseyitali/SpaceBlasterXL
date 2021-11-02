using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject[] spawnAreas;
    public int maxEnemiesAmountOnStart;
    public int extraEnemiesPerXTotalEnemies;
    public int currentEnemiesAmount = 0;
    public int totalEnemiesAmount = 0;

    int maxEnemies;

    private void Update()
    {
        maxEnemies = maxEnemiesAmountOnStart + totalEnemiesAmount / extraEnemiesPerXTotalEnemies;
        if (currentEnemiesAmount < maxEnemies)
        {
            SpawnRandomEnemy();
        }
        

    }

    public void SpawnRandomEnemy()
    {
        float rNumber = Random.value;

        CreateEnemy enemy;
        if (rNumber >= 0.5f)
        {
            enemy = CreateEnemy.GetNewPrimitive();
        }
        else if (rNumber >= 0.2f)
        {
            enemy = CreateEnemy.GetNewSplitter();
        }
        else
        {
            enemy = CreateEnemy.GetNewShooter();
        }

        SetupNewEnemy(enemy);
        currentEnemiesAmount++;
        totalEnemiesAmount++;
    }

    public void SetupNewEnemy(CreateEnemy enemy, GameObject spawnArea = null)
    {
        if (spawnArea == null)
        {
            int i = Random.Range(0, spawnAreas.Length);
            spawnArea = spawnAreas[i];
        }

        Vector3 spawnPosition = GetSpawnPosition(spawnArea);
        enemy.transform.position = spawnPosition;
        enemy.transform.parent = this.transform;

        EnemyMovementContoller enemyMovementContoller = enemy.movementContoller;

        if (spawnArea.name == "Left")
        {
            enemyMovementContoller.movementDirection = Vector3.right;
        }
        else if (spawnArea.name == "Right")
        {
            enemyMovementContoller.movementDirection = Vector3.left;
        }
        else if (spawnArea.name == "Top")
        {
            enemyMovementContoller.movementDirection = Vector3.down;
        }
        else if (spawnArea.name == "Bottom")
        {
            enemyMovementContoller.movementDirection = Vector3.up;
        }
    }

    Vector3 GetSpawnPosition(GameObject spawnArea)
    {
        Vector3 scale = spawnArea.transform.localScale;

        float x = spawnArea.transform.position.x + Random.Range(-scale.x/2, scale.x/2);
        float y = spawnArea.transform.position.y + Random.Range(-scale.y/2, scale.y/2);

        Vector3 location = new Vector3(x,y,0);

        return location;
    }
}
