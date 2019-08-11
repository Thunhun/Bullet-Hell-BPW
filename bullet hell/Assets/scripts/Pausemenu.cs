using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool ButtonEnabled = true;


    public GameObject pauseMenuUI;
    private void Start()
    {
        ButtonEnabled = true;
        GameIsPaused = false;
    }
    void Update()
    {
        if ((Input.GetButtonDown("Cancel")) && (Health.GameIsOver == false))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        ButtonEnabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        FindObjectOfType<AudioManager>().Play("Unpause");
    }

    void Pause()
    {
        ButtonEnabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Pause");
    }

    public void LoadMenu()
    {

        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Cursor.visible = false;
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;
        FindObjectOfType<AudioManager>().Play("Click");
    }
}

