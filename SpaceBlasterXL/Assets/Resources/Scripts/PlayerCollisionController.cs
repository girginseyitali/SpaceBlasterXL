using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    public CollectionController collectionController;
    
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "InnerBorder")
        {
            print("Destroy Player Ship");
            playerHealth.DestroyShip();
            
        }
        else if (collision.gameObject.tag == "EnemyCollider")
        {
            print("Touched Enemy");
            playerHealth.TakeDamage();
        }
        else if (collision.gameObject.tag == "Collectable")
        {
            collectionController.Collect(collision.gameObject);
        }
    }
}
