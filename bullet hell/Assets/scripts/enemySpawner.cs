using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {


    public GameObject[] enemies;
    public int amountSpawned = 0;
    public int enemiesPerWave = 5;
    public int wave = 0;
    public float timeBetweenSpawns = 1;
    public float startTime = 3;
    private Vector3 leftPos;
    private Vector3 rightPos;

    public bool spawnIng = true;
    public static enemySpawner instance;
    void Start () {
        instance = this;
        leftPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        rightPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        StartCoroutine(SpawningEnemyWave());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawningEnemyWave()
    {
        yield return new WaitForSeconds(startTime);
        amountSpawned = 0;
        while (amountSpawned < enemiesPerWave)
        {
            SpawnEnemy();
            amountSpawned++;
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
        SpawnEnemy(wave + 1);
        yield return new WaitForSeconds(timeBetweenSpawns);
        if (wave < enemies.Length - 2)
        {
            wave++;
            StartCoroutine(SpawningEnemyWave());
        }
        else
        {
            spawnIng = false;

        }
    }

    void SpawnEnemy(int type = -1)
    {

        int RandomInex = type;
        if (RandomInex == -1)
        {
            RandomInex = Random.Range(0, wave);
        }

        Transform spawnPos = transform; 
        spawnPos.position =  new Vector2(Random.Range(leftPos.x, rightPos.x), rightPos.y - 2f);
 
        GameObject enemy =  Instantiate(enemies[RandomInex]);
        enemy.transform.position = spawnPos.position;
    }
}
