using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Text highscoreText;
    public int highscoreInt;

    
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscoreInt = PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            highscoreInt = 0;
            PlayerPrefs.SetInt("Highscore", 0);
        }

        highscoreText.text = "Highscore: " + highscoreInt.ToString();
    }

    public void OnPlayClicked()
    {

        SceneManager.LoadScene(1);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
