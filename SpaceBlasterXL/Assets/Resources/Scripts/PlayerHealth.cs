using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    Score score;

    public int shieldAmount;
    public GameObject shipSprite;
    public float invincibleTime;
    public GameObject[] shieldSprites;

    bool invincible = false;

    public void TakeDamage()
    {
        if (!invincible)
        {
            shieldAmount--;
            if (shieldAmount <0)
            {
                DestroyShip();
                
                Debug.Log("Destroy Ship");
            }
            else
            {
                StartCoroutine(InvincibleAfterTakeDamage());
                Debug.Log("Toggle Invincibility");
            }
        }
    }

    public void DestroyShip()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        int _score = PlayerPrefs.GetInt("Highscore");
        if (score.currentScore > _score)
        {
            PlayerPrefs.SetInt("Highscore",score.currentScore);
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", _score);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    IEnumerator InvincibleAfterTakeDamage()
    {
        invincible = true;

        float invisTime = invincibleTime / 8;

        for (int i = 0; i < 4; i++)
        {
            shipSprite.SetActive(false);
            yield return new WaitForSeconds(invisTime);
            shipSprite.SetActive(true);
            yield return new WaitForSeconds(invisTime);
        }

        invincible = false;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < shieldSprites.Length; i++)
        {
            if (i < shieldAmount)
            {
                shieldSprites[i].SetActive(true);
            }
            else
            {
                shieldSprites[i].SetActive(false);
            }
        }
    }
}
