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
    private int qtdSlime;
    

    void Update(){
        GameObject[] allSlimes = GameObject.FindGameObjectsWithTag("Slime");
        qtdSlime = allSlimes.Length;

        Spawn();
    }
    
    void Spawn(){
        if (wait == true){
            
        }else{
            Levels levels = FindAnyObjectByType<Levels>();
            spawnTimer += Time.deltaTime;


            if (spawnTimer >= levels.spawnInterval){
                spawnTimer = 0f;

                int spawnIndex = Random.Range(0, spawnPoints.Length);
                int type = Random.Range(0, 2);
                int pai = Random.Range(0, 14);

                Transform spawnPoint = spawnPoints[spawnIndex];
                Score score = FindAnyObjectByType<Score>();

                if (score.scoreValue >= 30000)
                    pai = 1;

                if (pai == 0 && qtdSlime < 2){
                    GameObject slime;


                    if (spawnIndex == 0){
                        slime = Instantiate(hardEnemyLeft, spawnPoint.position, Quaternion.identity);
                    }
                    if (spawnIndex == 1){
                        slime = Instantiate(hardEnemyCenter, spawnPoint.position, Quaternion.identity);
                    }
                    if (spawnIndex == 2){ 
                        slime = Instantiate(hardEnemyRight, spawnPoint.position, Quaternion.identity);
                    }

                }
                else {
                if (spawnIndex == 0)
                {
                    GameObject enemy = Instantiate(commonEnemiesLeft[type], spawnPoint.position, Quaternion.identity);
                }
                else if (spawnIndex == 1)
                {
                    GameObject enemy = Instantiate(commonEnemiesCenter[type], spawnPoint.position, Quaternion.identity);
                }
                else if (spawnIndex == 2)
                {
                    GameObject enemy = Instantiate(commonEnemiesRight[type], spawnPoint.position, Quaternion.identity);
                }
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