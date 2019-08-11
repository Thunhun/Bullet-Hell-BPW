using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    private int Hp;
    public int maxHp = 5;
    public Healthbar healthbar;
    public GameObject healthBar;
    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;
    public GameObject loseMenuUI;



    void Start () {
        Hp = maxHp;
        GameIsOver = false;
        GameIsPaused = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Damage(int DamageValue)
    {
        Hp -= DamageValue;
        if (healthbar != null)
        {
            healthbar.UpdateHp( (float)Hp / (float)maxHp);
        }

        if (Hp <= 0)
        {
            Death();
        }
    }


    public void Death()
    {
        if (GetComponent<Enemy>() != null)
        {
            FindObjectOfType<AudioManager>().Play("Killed Enemy");
            if (enemySpawner.instance.spawnIng == false)
            {
                if (Transform.FindObjectsOfType<Enemy>().Length <= 1)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }

            }

        }
        if (GetComponent<Player>() != null)
        {
            healthBar.SetActive(false);
            loseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            GameIsOver = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            FindObjectOfType<AudioManager>().Play("Killed Player");

            FindObjectOfType<AudioManager>().Play("GameOver");


        }
        Destroy(gameObject);
    }





}
