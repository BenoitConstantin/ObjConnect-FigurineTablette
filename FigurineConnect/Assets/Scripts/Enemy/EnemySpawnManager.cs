using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnManager : MonoBehaviour {

    public int spawnRate = 2;
    public EnemySpawner[] spawnPoints;
    private float timeUntilNextSpawn;
    public int totalNumberOfEnemies = 0;

    private void Start()
    {
        for (int i = 0; i < spawnPoints.Length; ++i)
        {
            totalNumberOfEnemies += spawnPoints[i].spawnNumber;
        }
    }

    void Update()
    {
        if (spawnPoints.Length > 0)
        {
            if (timeUntilNextSpawn <= 0)
            {
                int randomNest = Random.Range(0, spawnPoints.Length);

                if (spawnPoints[randomNest].spawnNumber > 0)
                {
                    spawnPoints[randomNest].SpawnEnemy();
                }
                else
                {
                    List<EnemySpawner> tempList = new List<EnemySpawner>();
                    for (int i = 0; i < spawnPoints.Length; i++)
                    {
                        if (i != randomNest)
                        {
                            tempList.Add(spawnPoints[i]);
                        }
                    }
                    EnemySpawner[] tempArray = new EnemySpawner[spawnPoints.Length-1];
                    tempList.CopyTo(tempArray);

                    spawnPoints = tempArray;
                    if (spawnPoints.Length > 0)
                    {
                        randomNest = Random.Range(0, spawnPoints.Length);
                        spawnPoints[randomNest].SpawnEnemy();
                    }
                }
                timeUntilNextSpawn = spawnRate;
            }
            timeUntilNextSpawn -= 1 * Time.deltaTime;
        }

        if(totalNumberOfEnemies <= 0)
        {
            SoundManager.Instance.PlayEndGameSFX(true);
            if (GameManager.Instance == null) {
               // SceneManager.LoadScene("Win");
            } else {
                GameManager.Instance.EndParty(true);
            }
            
        }
    }
}
