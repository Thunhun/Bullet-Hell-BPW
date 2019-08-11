using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void Playgame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl1");
        Cursor.visible = false;
    }

  public void Playgame2()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl2");
        Cursor.visible = false;
    }

  public void Playgame3()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl3");
        Cursor.visible = false;
    }

    public void Playgame4()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl4");
        Cursor.visible = false;
    }

    public void Click()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void QuitGame()
    {

        Application.Quit();

    }

}
