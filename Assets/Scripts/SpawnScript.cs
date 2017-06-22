using System.Collections;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public Transform enemyObject;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public float timeBeforeStart = 2f;
    public int enemiesPerWave = 0;
    public float timeBetweenEnemySpawn = 2f;
    public int maximumEnemies = 10;

    public static int enemiesAlives = 0;
    void Update()
    {
        if (timeBeforeStart <= 0f)
        {
            StartCoroutine(SpawnWave());
            timeBeforeStart = timeBetweenWaves;
        }

        timeBeforeStart -= Time.deltaTime;
        timeBeforeStart = Mathf.Clamp(timeBeforeStart, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {

        for(int i = 0; i<enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }
    }

    void SpawnEnemy()
    {
        if (enemiesAlives < maximumEnemies)
        {
            var enemyTransform = Instantiate(enemyObject, spawnPoint.position, spawnPoint.rotation, transform);
            EnemyBehaviour enemy = enemyTransform.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.MoveAlong = "Path" + Random.Range(1, 4);
            }

            enemiesAlives++;
        }
    }
}