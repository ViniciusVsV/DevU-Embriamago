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
    private int apenasum = 0;
    

    void Update(){
        Spawn();
    }
    
    void Spawn(){
        
        if (wait == true){
            
        }else{
            Levels levels = FindAnyObjectByType<Levels>();
            spawnTimer += Time.deltaTime;


            if (spawnTimer >= levels.spawnInterval)
            {
                spawnTimer = 0f;

                int spawnIndex = Random.Range(0, spawnPoints.Length);
                int type = Random.Range(0, 2);
                int pai = Random.Range(0, 9);

                Transform spawnPoint = spawnPoints[spawnIndex];
                Score score = FindAnyObjectByType<Score>();
                SlimeHealth slimehealth = gameObject.GetComponent<SlimeHealth>();

                if (score.scoreValue >= 3500)
                    pai = 1;

                if (pai == 0 && apenasum < 3)
                {
                    GameObject slime;


                    if (spawnIndex == 0)
                    {
                        slime = Instantiate(hardEnemyLeft, spawnPoint.position, Quaternion.identity);
                        apenasum++;
                    }
                    if (spawnIndex == 1)
                    {
                        slime = Instantiate(hardEnemyCenter, spawnPoint.position, Quaternion.identity);
                        apenasum++;
                    }
                    if (spawnIndex == 2) { 
                        slime = Instantiate(hardEnemyRight, spawnPoint.position, Quaternion.identity);
                        apenasum++;
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