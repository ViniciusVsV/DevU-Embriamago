using UnityEngine;

public class Levels : MonoBehaviour{
    private int currentScore = 0;
    
    public float enemySpeed;
    public float attackCooldown;
    public float moveDelay;
    public float spawnInterval;

    private bool isInsane = false;
    private bool isImpossible = false;
  
    void Start(){
        setDificultyStart();
    }

    void Update(){
        Score score = FindAnyObjectByType<Score>();
        currentScore = score.getScore();

        if(currentScore >= 1000 && currentScore < 5000)
            setDificultyEasy();


        if(currentScore >= 5000 && currentScore < 15000)
            setDificultyModerate();

        if(currentScore >= 15000 && currentScore < 40000)
            setDificultyHard();

        if(currentScore >= 40000 && currentScore < 150000)
            setDificultyInsane();

        if(currentScore >= 150000)
            setDificultyImpossible();
    }

    void setDificultyStart(){
        spawnInterval = 1.6f;
        enemySpeed = 10f;
        attackCooldown = 0.8f;
        moveDelay = 0.4f;
    }

    void setDificultyEasy(){
        spawnInterval = 1f;
        enemySpeed = 16f;
        attackCooldown = 0.6f;
        moveDelay = 0.3f;
    }

    void setDificultyModerate(){
        spawnInterval = 0.7f;
        enemySpeed = 18f;
        attackCooldown = 0.5f;
        moveDelay = 0.2f;
    }
    
    void setDificultyHard(){
        spawnInterval = 0.4f;
        enemySpeed = 20f;
        attackCooldown = 0.3f;
        moveDelay = 0.1f;
    }

    void setDificultyInsane(){
        if(isInsane == false){
            SpeedLinesController speedLines = FindAnyObjectByType<SpeedLinesController>();
            speedLines.startSpeedLines();
        }
        isInsane = true;

        CameraShake cameraShake = FindAnyObjectByType<CameraShake>();
        cameraShake.ShakeCamera();

        spawnInterval = 0.2f;
        enemySpeed = 25f;
        attackCooldown = 0.1f;
        moveDelay = 0f;
    }

    void setDificultyImpossible(){
        if(isImpossible == false){
            SpeedLinesController speedLines = FindAnyObjectByType<SpeedLinesController>();
            speedLines.startSpeedLines();
        }
        isImpossible = true;

        CameraShake cameraShake = FindAnyObjectByType<CameraShake>();
        cameraShake.ShakeCamera();

        spawnInterval = 0.1f;
        enemySpeed = 35f;
        attackCooldown = 0f;
        moveDelay = 0f;
    }
}
