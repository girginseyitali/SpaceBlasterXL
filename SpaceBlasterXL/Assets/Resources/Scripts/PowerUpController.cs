using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public float basicDuration;
    public bool isPowerUpActive = false;

    public MultiShot multiShot;
    public GameObject laser;
    public GameObject berserkAurora;

    float activeUntilTime = 0f;
    string powerUpType = "multiShot"; //multiShot, laser, berserk


    void Start()
    {
        //ActivatePowerUp("berserk");
        isPowerUpActive = false;
    }

    
    void Update()
    {
        if (isPowerUpActive && Time.time < activeUntilTime)
        {
            if (powerUpType == "multiShot")
            {
                multiShot.ShootRepeating();
            }
            else if (powerUpType == "laser")
            {
                laser.SetActive(true);
            }
            else if (powerUpType == "berserk")
            {
                berserkAurora.SetActive(true);
            }
        }
        else
        {
            powerUpType = null;
            isPowerUpActive = false;
        }
        if (powerUpType != "laser")
        {
            laser.SetActive(false);
        }else if(powerUpType != "berserk")
        {
            berserkAurora.SetActive(false);
        }
    }

    public void ActivatePowerUp(string _powerUpType)
    {
        powerUpType = _powerUpType;
        isPowerUpActive = true;
        activeUntilTime = Time.time + basicDuration;
    }

    void DeactivatePowerUp(string _powerUpType)
    {
        powerUpType = _powerUpType;
        isPowerUpActive = false;
    }
}
