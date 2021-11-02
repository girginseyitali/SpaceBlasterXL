using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : MonoBehaviour
{
    public float shootRate;
    float nextShoot = 0f;
    public float bulletSpeed;

    public GameObject playerBulletPrefab;
    public GameObject bullets;
    public GameObject[] multiShotSpawnPoints;
    
    public void ShootRepeating()
    {
        if (Time.time > nextShoot + shootRate)
        {
            nextShoot = Time.time;

            foreach (GameObject bulletSpawnPoint in multiShotSpawnPoints)
            {

                GameObject newBullet = Instantiate(playerBulletPrefab);
                newBullet.transform.position = bulletSpawnPoint.transform.position;
                newBullet.transform.parent = bullets.transform;

                Rigidbody2D newBulletRb = newBullet.GetComponent<Rigidbody2D>();

                Vector3 dir = (bulletSpawnPoint.transform.position - gameObject.transform.position).normalized;

                newBulletRb.AddForce(bulletSpeed * dir);
            }
        }
        
    }
}
