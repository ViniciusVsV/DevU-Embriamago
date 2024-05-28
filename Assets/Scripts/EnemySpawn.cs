using UnityEngine;

public class EnemySpawn : MonoBehaviour{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab0;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;

    private float spawnInterval = 2f;
    private float spawnTimer = 0f;

    void Update(){
        spawnTimer += Time.deltaTime;
        
        if(spawnTimer >= spawnInterval){
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

    public void setSpawnInterval(float newSpawnInterval){
        spawnInterval = newSpawnInterval;
    }
}
