using System.Collections;
using TMPro;
using UnityEngine;

public class Levels : MonoBehaviour{
    private int currentScore = 0;
    
    public float enemySpeed;
    public float attackCooldown;
    public float moveDelay;
    public float spawnInterval;

    public TMP_Text startingText;
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text text4;
    public TMP_Text text5;
  
    void Start(){
        StartCoroutine(setDificultyStart(startingText.gameObject, 4f));
    }

    void Update(){
        Score score = FindAnyObjectByType<Score>();
        currentScore = score.getScore();

        if(currentScore == 500){
            levelTransition(1);
        }
        else if(currentScore == 3500){
            levelTransition(2);
        }
        else if(currentScore == 10000){
            levelTransition(3);
        }
        else if(currentScore == 30000){
            levelTransition(4);
        }
        else if(currentScore == 100000){
            levelTransition(5);
        }
    }

    void levelTransition(int selector){
        EnemySpawn enemySpawn = FindAnyObjectByType<EnemySpawn>();
        StartCoroutine(enemySpawn.DelaySpawn(4));
        
        switch(selector){
            case 1:
                StartCoroutine(setDificultyEasy(text1.gameObject, 4f));
                break;
            case 2:
                StartCoroutine(setDificultyModerate(text2.gameObject, 4f));
                break;
            case 3:
                StartCoroutine(setDificultyHard(text3.gameObject, 4f));
                break;
            case 4:
                StartCoroutine(setDificultyInsane(text4.gameObject, 4f));
                break;
            case 5:
                StartCoroutine(setDificultyImpossible(text5.gameObject, 4f));
                break;
        }
    }

    IEnumerator setDificultyStart(GameObject obj, float delay){
        spawnInterval = 1.6f;
        enemySpeed = 8f;
        attackCooldown = 0.8f;
        moveDelay = 0.4f;

        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);
    }

    IEnumerator setDificultyEasy(GameObject obj, float delay){
        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        spawnInterval = 1f;
        enemySpeed = 16f;
        attackCooldown = 0.6f;
        moveDelay = 0.3f;
    }

    IEnumerator setDificultyModerate(GameObject obj, float delay){
        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        TextWobble textWobble = FindAnyObjectByType<TextWobble>();
        textWobble.wobble = true;

        spawnInterval = 0.7f;
        enemySpeed = 17f;
        attackCooldown = 0.5f;
        moveDelay = 0.2f;
    }
    
    IEnumerator setDificultyHard(GameObject obj, float delay){
        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        SpeedLinesController speedLines = FindAnyObjectByType<SpeedLinesController>();
        speedLines.startSpeedLines(1);

        
        HeartVibration[] hearts = FindObjectsOfType<HeartVibration>(); 
        foreach(HeartVibration heart in hearts)
            heart.vibrate = true;

        spawnInterval = 0.4f;
        enemySpeed = 18f;
        attackCooldown = 0.3f;
        moveDelay = 0.1f;
    }

    IEnumerator setDificultyInsane(GameObject obj, float delay){
        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        SpeedLinesController speedLines = FindAnyObjectByType<SpeedLinesController>();
        speedLines.startSpeedLines(2);

        CameraShake cameraShake = FindAnyObjectByType<CameraShake>();
        cameraShake.ShakeCamera();

        spawnInterval = 0.2f;
        enemySpeed = 23f;
        attackCooldown = 0.2f;
        moveDelay = 0f;
    }

    IEnumerator setDificultyImpossible(GameObject obj, float delay){
        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        SpeedLinesController speedLines = FindAnyObjectByType<SpeedLinesController>();
        speedLines.startSpeedLines(3);

        CameraShake cameraShake = FindAnyObjectByType<CameraShake>();
        cameraShake.ShakeCamera();

        spawnInterval = 0.2f;
        enemySpeed = 35f;
        attackCooldown = 0.1f;
        moveDelay = 0f;
    }
}
