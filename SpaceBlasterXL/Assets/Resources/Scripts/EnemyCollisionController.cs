using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    Enemies enemiesScript;
    private void Awake()
    {
        GameObject gaObj = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        enemiesScript = gaObj.GetComponent<Enemies>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OuterBorder")
        {
            Debug.Log("ENEMY HIT OUTER BORDER");
            enemiesScript.currentEnemiesAmount--;
            Destroy(transform.parent.gameObject);
        }
    }
}
