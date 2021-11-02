using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject powerUpLaser;
    public GameObject powerUpBerserk;
    public GameObject powerUpMultiShot;

    public GameObject resourceAmmo;
    public GameObject resourceShield;
    public GameObject resourceBomb;

    public float powerUpSpawnChange = .1f;

    public void SpawnRandomCollectable(Transform pos)
    {
        if (Random.value <= powerUpSpawnChange)
        {
            SpawnRandomPowerUp(pos);
        }
        else
        {
            SpawnRandomResource(pos);
        }
    }

    public void SpawnRandomPowerUp(Transform pos)
    {
        float v = Random.value;

        Collectable newCollectable;

        if (v > .5f)
        {
            newCollectable = Collectable.CreateMultiShot();
        }else if (v < .2f) {
            newCollectable = Collectable.CreateBerserk();
        }
        else
        {
            newCollectable = Collectable.CreateLaser();
        }

        newCollectable.transform.position = pos.position;
    }

    public void SpawnRandomResource(Transform pos)
    {
        float v = Random.value;

        Collectable newCollectable;

        if (v >= .1f)
        {
            newCollectable = Collectable.CreateAmmo();
        }
        else if (v >= .05f)
        {
            newCollectable = Collectable.CreateBomb();
        }
        else
        {
            newCollectable = Collectable.CreateShield();
        }

        newCollectable.transform.position = pos.position;
    }



}
