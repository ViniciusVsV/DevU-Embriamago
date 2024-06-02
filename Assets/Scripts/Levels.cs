using System.Collections;
using TMPro;
using UnityEngine;

public class Levels : MonoBehaviour{
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
        StartCoroutine(setDificultyStart(startingText.gameObject));
    }

    public void levelTransition(int selector){
        EnemySpawn enemySpawn = FindAnyObjectByType<EnemySpawn>();
        StartCoroutine(enemySpawn.DelaySpawn(4));
        
        switch(selector){
            case 1:
                StartCoroutine(setDificultyEasy(text1.gameObject));
                break;
            case 2:
                StartCoroutine(setDificultyModerate(text2.gameObject));
                break;
            case 3:
                StartCoroutine(setDificultyHard(text3.gameObject));
                break;
            case 4:
                StartCoroutine(setDificultyInsane(text4.gameObject));
                break;
            case 5:
                StartCoroutine(setDificultyImpossible(text5.gameObject));
                break;
        }
    }

    IEnumerator setDificultyStart(GameObject obj){
        spawnInterval = 1.6f;
        enemySpeed = 8f;
        attackCooldown = 0.8f;
        moveDelay = 0.4f;

        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);
    }

    IEnumerator setDificultyEasy(GameObject obj){
        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        spawnInterval = 1f;
        enemySpeed = 16f;
        attackCooldown = 0.6f;
        moveDelay = 0.3f;
    }

    IEnumerator setDificultyModerate(GameObject obj){
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
    
    IEnumerator setDificultyHard(GameObject obj){
        AudioController audioController = FindAnyObjectByType<AudioController>();
        StartCoroutine(audioController.stopMusic());

        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        audioController.setMusicFast();

        SpeedLinesController speedLines = FindAnyObjectByType<SpeedLinesController>();
        speedLines.startSpeedLines(1);
        
        HeartVibration[] hearts = FindObjectsOfType<HeartVibration>(); 
        foreach(HeartVibration heart in hearts)
            heart.vibrate = true;

        CameraController cameraController = FindAnyObjectByType<CameraController>();
        cameraController.ShakeCamera(0.2f);
        cameraController.IncreaseFOV(61f);

        spawnInterval = 0.4f;
        enemySpeed = 18f;
        attackCooldown = 0.3f;
        moveDelay = 0.1f;
    }

    IEnumerator setDificultyInsane(GameObject obj){
        AudioController audioController = FindAnyObjectByType<AudioController>();
        StartCoroutine(audioController.stopMusic());

        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        audioController.setMusicInsane();

        SpeedLinesController speedLines = FindAnyObjectByType<SpeedLinesController>();
        speedLines.startSpeedLines(2);

        CameraController cameraController = FindAnyObjectByType<CameraController>();
        cameraController.ShakeCamera(0.6f);
        cameraController.IncreaseFOV(62f);

        spawnInterval = 0.2f;
        enemySpeed = 23f;
        attackCooldown = 0.1f;
        moveDelay = 0f;
    }

    IEnumerator setDificultyImpossible(GameObject obj){
        AudioController audioController = FindAnyObjectByType<AudioController>();
        StartCoroutine(audioController.stopMusic());

        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        audioController.setMusicInsane();

        SpeedLinesController speedLines = FindAnyObjectByType<SpeedLinesController>();
        speedLines.startSpeedLines(3);

        CameraController cameraController = FindAnyObjectByType<CameraController>();
        cameraController.ShakeCamera(1f);
        cameraController.IncreaseFOV(63f);

        spawnInterval = 0.2f;
        enemySpeed = 35f;
        attackCooldown = 0.1f;
        moveDelay = 0f;
    }
}
