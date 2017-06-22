using System.Collections;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public Transform strongEnemyObject;
    public Transform NormalEnemyObject;
    public Transform FastEnemyObject;
    public Transform Paths;
    public float timeBetweenWaves = 10f;
    public float timeBeforeStart = 0f;
    public int enemiesPerWave = 2;
    public float timeBetweenEnemySpawn = 2f;
    public int maximumEnemies = 7;

    [HideInInspector]
    public static int enemiesAlives = 0;

    private void Start()
    {
        enemiesAlives = 0;
    }

    void Update()
    {
        if (TimeLogic.IsRunning())
        {
            if (timeBeforeStart <= 0f)
            {
                StartCoroutine(SpawnWave());
                timeBeforeStart = timeBetweenWaves;
            }

            timeBeforeStart -= Time.deltaTime;
        }
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
            Transform enemyObject;
            var r = Random.Range(1, 10);
            switch (r)
            {
                case 1:
                    enemyObject = strongEnemyObject;
                    break;
                case 2:
                    enemyObject = FastEnemyObject;
                    break;
                default:
                    enemyObject = NormalEnemyObject;
                    break;
            }

            var path = Paths.transform.GetChild(Random.Range(0, Paths.transform.childCount));
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