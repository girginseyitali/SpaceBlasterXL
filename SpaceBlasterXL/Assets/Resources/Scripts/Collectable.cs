using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float duration;
    float killTime;

    public float blinkTime;
    bool isBlinking = false;

    public string collectableType;

    SpriteRenderer collectableSprite;

    private void Start()
    {
        killTime = Time.time + duration;
        collectableSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if ((Time.time > killTime - blinkTime) && !isBlinking)
        {
            StartCoroutine(Blink());
            isBlinking = true;
        }
        if (Time.time >killTime)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Blink()
    {
        for (int i = 0; i < 4; i++)
        {
            collectableSprite.enabled = false;
            yield return new WaitForSeconds(.25f);
            collectableSprite.enabled = true;
            yield return new WaitForSeconds(.25f);
        }
    }

    public static Collectable CreateAmmo()
    {
        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefabs/Ammo"));
        return ammo.GetComponent<Collectable>();
    }

    public static Collectable CreateShield()
    {
        GameObject shield = (GameObject)Instantiate(Resources.Load("Prefabs/Shield"));
        return shield.GetComponent<Collectable>();
    }

    public static Collectable CreateLaser()
    {
        GameObject laser = (GameObject)Instantiate(Resources.Load("Prefabs/Laser"));
        return laser.GetComponent<Collectable>();
    }

    public static Collectable CreateBerserk()
    {
        GameObject berserk = (GameObject)Instantiate(Resources.Load("Prefabs/Berserk"));
        return berserk.GetComponent<Collectable>();
    }

    public static Collectable CreateMultiShot()
    {
        GameObject multishot = (GameObject)Instantiate(Resources.Load("Prefabs/MultiShot"));
        return multishot.GetComponent<Collectable>();
    }

    public static Collectable CreateBomb()
    {
        GameObject bomb = (GameObject)Instantiate(Resources.Load("Prefabs/Bomb"));
        return bomb.GetComponent<Collectable>();
    }
}
