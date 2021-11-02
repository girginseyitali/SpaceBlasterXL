using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    [Header("Variables")]
    public float shootRate;
    public float bulletSpeed;
    public int ammoAmount;

    public GameObject playerBulletPrefab;
    public GameObject bullets;
    public Transform bulletSpawnPoint;
    public Text ammoText; 

    float nextShoot = 0;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.M) && Time.time > nextShoot && ammoAmount > 0)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        ammoText.text = ammoAmount.ToString();
    }

    void Shoot()
    {
        this.nextShoot = Time.time + shootRate;
        GameObject newBullet = Instantiate(playerBulletPrefab);
        newBullet.transform.position = bulletSpawnPoint.transform.position;
        newBullet.transform.parent = bullets.transform;

        Rigidbody2D newBulletRb = newBullet.GetComponent<Rigidbody2D>();
        newBulletRb.AddForce(bulletSpeed * transform.up);
        ammoAmount--;

        ammoText.text = ammoAmount.ToString();
    }
}
