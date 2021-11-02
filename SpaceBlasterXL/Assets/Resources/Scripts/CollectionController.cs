using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
    public ShootController shootController;
    public PlayerHealth playerHealth;
    public BombController bombController;
    public PowerUpController powerUpController;

    public int ammoAmount;

    public void Collect(GameObject collectable)
    {
        Collectable collectableScript = collectable.GetComponent<Collectable>();

        string collectableType = collectableScript.collectableType;

        if (collectableType == "Ammo")
        {
            shootController.ammoAmount += ammoAmount;
        }else if (collectableType == "Shield")
        {
            if (playerHealth.shieldAmount < 5)
            {
                playerHealth.shieldAmount++;
            }
        }
        else if (collectableType == "Bomb")
        {
            if (bombController.bombAmount < 5)
            {
                bombController.bombAmount++;
            }
        }else if (collectableType == "Berserk")
        {
            powerUpController.ActivatePowerUp("berserk");
        }else if (collectableType == "Laser")
        {
            powerUpController.ActivatePowerUp("laser");
        }else if(collectableType == "MultiShot")
        {
            powerUpController.ActivatePowerUp("multiShot");
        }

        Destroy(collectable);
    }
   
}
