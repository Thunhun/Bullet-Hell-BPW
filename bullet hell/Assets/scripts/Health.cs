﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    private int Hp;
    public int maxHp = 5;
    public Healthbar healthbar;
    public static bool GameIsPaused = false;

    public GameObject loseMenuUI;
    public GameObject winMenuUI;

    void Start () {
        Hp = maxHp;
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

    void Death()
    {
        if (GetComponent<Enemy>() != null)
        {
            if (enemySpawner.instance.spawnIng == false)
            {
                if (Transform.FindObjectsOfType<Enemy>().Length <= 1)
                {
                    Debug.Log("victory");
                    winMenuUI.SetActive(true);
                    Time.timeScale = 0f;
                    GameIsPaused = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }

            }

        }
        if (GetComponent<Player>() != null)
        {
            Debug.Log("game over");
            loseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        Destroy(gameObject);
    }




}
