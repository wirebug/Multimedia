using System.Collections;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public Transform enemyObject;
    public float timeBetweenWaves = 10f;
    public float timeBeforeStart = 0f;
    public int enemiesPerWave = 2;
    public float timeBetweenEnemySpawn = 2f;
    public int maximumEnemies = 7;

    public static int enemiesAlives = 0;
    void Update()
    {
        if (timeBeforeStart <= 0f)
        {
            StartCoroutine(SpawnWave());
            timeBeforeStart = timeBetweenWaves;
        }

        timeBeforeStart -= Time.deltaTime;
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
            var pathName = "Path" + Random.Range(1, 4); 
            var path = GameObject.Find(pathName);
            var spawnPoint = path.transform.GetChild(Random.Range(0, path.transform.childCount));

            var enemyTransform = Instantiate(enemyObject, spawnPoint.position, spawnPoint.rotation, transform);
            EnemyBehaviour enemy = enemyTransform.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.MoveAlong = path.transform;
            }

            enemiesAlives++;
        }
    }
}