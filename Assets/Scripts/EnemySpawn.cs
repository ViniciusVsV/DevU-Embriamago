using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
    public Transform[] spawnPoints;
    public GameObject[] commonEnemiesCenter;
    public GameObject[] commonEnemiesLeft;
    public GameObject[] commonEnemiesRight;
    public GameObject hardEnemyCenter;
    public GameObject hardEnemyLeft;
    public GameObject hardEnemyRight;

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
                    
                }else if(spawnIndex == 1){
                    
                }else if(spawnIndex == 2){
                    
                    
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