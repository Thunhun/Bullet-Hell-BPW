using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void Playgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl1");
    }

  public void Playgame2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl2");
    }

  public void Playgame3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl3");
    }

    public void QuitGame()
    {
        Application.Quit();

    }

}
