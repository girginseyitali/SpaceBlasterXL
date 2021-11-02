using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollisionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyCollider")
        {
            EnemyDestroyController enemyDestroyController = collision.transform.parent.GetComponent<EnemyDestroyController>();
            enemyDestroyController.DestroyByPlayer();
        }
    }
}
