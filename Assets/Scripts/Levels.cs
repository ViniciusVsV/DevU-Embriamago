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
        spawnInterval = 2f;
        enemySpeed = 10f;
        attackCooldown = 0.4f;
        moveDelay = 0.2f;

        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);
    }

    IEnumerator setDificultyEasy(GameObject obj){
        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        spawnInterval = 1.5f;
        enemySpeed = 15f;
        attackCooldown = 0.4f;
        moveDelay = 0.2f;
    }

    IEnumerator setDificultyModerate(GameObject obj){
        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        TextWobble textWobble = FindAnyObjectByType<TextWobble>();
        textWobble.wobble = true;

        spawnInterval = 1f;
        enemySpeed = 20f;
        attackCooldown = 0.4f;
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
        
        HeartController[] hearts = FindObjectsOfType<HeartController>(); 
        foreach(HeartController heart in hearts)
            heart.vibrate = true;

        CameraController cameraController = FindAnyObjectByType<CameraController>();
        cameraController.ShakeCamera(0.2f);
        cameraController.IncreaseFOV(61f);

        spawnInterval = 0.5f;
        enemySpeed = 25f;
        attackCooldown = 0.2f;
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

        spawnInterval = 0.25f;
        enemySpeed = 30f;
        attackCooldown = 0.1f;
        moveDelay = 0.05f;
    }

    IEnumerator setDificultyImpossible(GameObject obj){
        AudioController audioController = FindAnyObjectByType<AudioController>();
        StartCoroutine(audioController.stopMusic());

        obj.SetActive(true);
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);

        audioController.setMusicImpossible();

        SpeedLinesController speedLines = FindAnyObjectByType<SpeedLinesController>();
        speedLines.startSpeedLines(3);

        CameraController cameraController = FindAnyObjectByType<CameraController>();
        cameraController.ShakeCamera(1f);
        cameraController.IncreaseFOV(63f);

        spawnInterval = 0.2f;
        enemySpeed = 40f;
        attackCooldown = 0.1f;
        moveDelay = 0f;
    }
}
