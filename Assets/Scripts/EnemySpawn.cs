using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab0;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject civilPrefab0;
    public GameObject civilPrefab1;
    public GameObject civilPrefab2;


    private float spawnTimer = 0f;
    private bool wait = false;

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {


        if (wait == true)
        {

        }
        else
        {
            Levels levels = FindAnyObjectByType<Levels>();
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= levels.spawnInterval)
            {
                spawnTimer = 0f;

                int spawnIndex = Random.Range(0, spawnPoints.Length);
                int spawntype = Random.Range(0, 20);

                Transform spawnPoint = spawnPoints[spawnIndex];

                if (spawntype == 0)
                {
                    if (spawnIndex == 0)
                    {
                        GameObject civil = Instantiate(civilPrefab0, spawnPoint.position, Quaternion.identity);
                    }
                    else if (spawnIndex == 1)
                    {
                        GameObject civil = Instantiate(civilPrefab1, spawnPoint.position, Quaternion.identity);
                    }
                    else if (spawnIndex == 2)
                    {
                        GameObject civil = Instantiate(civilPrefab2, spawnPoint.position, Quaternion.identity);
                    }
                }
                else
                {

                    if (spawnIndex == 0)
                    {
                        GameObject enemy = Instantiate(enemyPrefab0, spawnPoint.position, Quaternion.identity);
                    }
                    else if (spawnIndex == 1)
                    {
                        GameObject enemy = Instantiate(enemyPrefab1, spawnPoint.position, Quaternion.identity);
                    }
                    else if (spawnIndex == 2)
                    {
                        GameObject enemy = Instantiate(enemyPrefab2, spawnPoint.position, Quaternion.identity);
                    }
                }
            }
        }
    }

    public IEnumerator DelaySpawn(int delayTime)
    {
        wait = true;
        yield return new WaitForSeconds(delayTime);
        wait = false;
    }
}
