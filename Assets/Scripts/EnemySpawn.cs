using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab0;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;

    public GameObject slimePrefab0;
    public GameObject slimePrefab1;
    public GameObject slimePrefab2;

    public GameObject DividedSlimePrefab0;
    public GameObject DividedSlimePrefab1;
    public GameObject DividedSlimePrefab2;

    private float spawnTimer = 0f;
    private bool wait = false;

    void Update(){
        Spawn();
    }

    void Spawn(){
        if(wait == true){
            
        }else{
            Levels levels = FindAnyObjectByType<Levels>();
            spawnTimer += Time.deltaTime;
            
            if(spawnTimer >= levels.spawnInterval){
                spawnTimer = 0f;

                int spawnIndex = Random.Range(0, spawnPoints.Length);
                int spawnEnemy = 0;

                Transform spawnPoint = spawnPoints[spawnIndex];

                if(spawnIndex == 0){
                    if(spawnEnemy == 0){
                        GameObject enemy = Instantiate(slimePrefab0, spawnPoint.position, Quaternion.identity);
                    }else{
                        GameObject enemy = Instantiate(enemyPrefab0, spawnPoint.position, Quaternion.identity);
                    }
                }else if(spawnIndex == 1){
                    if(spawnEnemy == 0){
                        GameObject enemy = Instantiate(slimePrefab1, spawnPoint.position, Quaternion.identity);
                    }else{
                        GameObject enemy = Instantiate(enemyPrefab1, spawnPoint.position, Quaternion.identity);
                    }
                }else if(spawnIndex == 2){
                    if(spawnEnemy == 0){
                        GameObject enemy = Instantiate(slimePrefab2, spawnPoint.position, Quaternion.identity);
                    }else{
                        GameObject enemy = Instantiate(enemyPrefab2, spawnPoint.position, Quaternion.identity);
                    }
                }
            }
        }
    }

    public void SlimeDeath(){
        GameObject enemy = Instantiate(DividedSlimePrefab0, spawnPoints[0].position, Quaternion.identity);
        GameObject enemy2 = Instantiate(DividedSlimePrefab1, spawnPoints[1].position, Quaternion.identity);
    }

    public IEnumerator DelaySpawn(int delayTime){
        wait = true;
        yield return new WaitForSeconds(delayTime);
        wait = false;
    }
}