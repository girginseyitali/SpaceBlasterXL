using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public EnemyMovementContoller movementContoller;

    public static CreateEnemy GetNewPrimitive()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/EnemyPrimitive"));
        return enemy.GetComponent<CreateEnemy>();
    }

    public static CreateEnemy GetNewSplitter()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/EnemyPrimitiveSplitter"));
        return enemy.GetComponent<CreateEnemy>();
    }

    public static CreateEnemy GetNewShooter()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/EnemyShooting"));
        return enemy.GetComponent<CreateEnemy>();
    }
}
