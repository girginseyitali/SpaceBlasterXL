using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollisionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "InnerBorder")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "EnemyCollider")
        {
            // TODO: Destroy enemy

            EnemyDestroyController enemyDestroyController = collision.transform.parent.GetComponent<EnemyDestroyController>();
            enemyDestroyController.DestroyByPlayer();

            Destroy(gameObject);
        }
    }
}
