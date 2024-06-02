using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab0;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;

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
                Transform spawnPoint = spawnPoints[spawnIndex];

                if(spawnIndex == 0){
                    GameObject enemy = Instantiate(enemyPrefab0, spawnPoint.position, Quaternion.identity);
                }else if(spawnIndex == 1){
                    GameObject enemy = Instantiate(enemyPrefab1, spawnPoint.position, Quaternion.identity);
                }else if(spawnIndex == 2){
                    GameObject enemy = Instantiate(enemyPrefab2, spawnPoint.position, Quaternion.identity);
                }
            }
        }
    }

    public IEnumerator DelaySpawn(int delayTime){
        wait = true;
        yield return new WaitForSeconds(delayTime);
        wait = false;
    }
}