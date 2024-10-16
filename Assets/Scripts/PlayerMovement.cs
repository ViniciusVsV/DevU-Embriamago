using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour{
    public Animator animator;

    public Transform[] routes;
    public GameObject projectilePrefabCenter;
    public GameObject projectilePrefabSide0;
    public GameObject projectilePrefabSide2;
    public Transform projectileSpawn;
    public GameObject GameOverPanel;
    public GameObject CanvasScore;
    public GameObject ScoreCounter;
    public GameObject Hearts;

    private int currentRouteIndex;
    private float cooldownTimer = 0;
    private bool allowShoot = true;

    private bool allowMove = true;


    public int health = 3;
    public GameObject[] healthBar; 

    void Start(){
        currentRouteIndex = 1;
        animator.SetInteger("Route", currentRouteIndex);
        StartCoroutine(ActivateHealthBars());
        Debug.Log("O jogo começou!");
    }

    void Update(){
        cooldownTimer += Time.deltaTime;

        HandleMovement();
        HandleShooting();

        if(health <= 0)
        {
            GameOver();
        }
    }

    //Mecânica de Movimento do Player
    void HandleMovement(){
        if(Input.GetKeyDown(KeyCode.A) && allowMove){
            currentRouteIndex = 0;
            StartCoroutine(MoveAfterDelay());
        }

        else if(Input.GetKeyDown(KeyCode.S) && allowMove){
            currentRouteIndex = 1;
            StartCoroutine(MoveAfterDelay());
        }

        else if(Input.GetKeyDown(KeyCode.D) && allowMove){
            currentRouteIndex = 2;
            StartCoroutine(MoveAfterDelay());
        }
    }

    void MoveToRoute(){
        transform.position = new Vector3(routes[currentRouteIndex].position.x, transform.position.y, transform.position.z);
        animator.SetInteger("Route", currentRouteIndex);
    }

    //Mecânica de Ataque
    void HandleShooting(){
        Levels levels = FindAnyObjectByType<Levels>();

        if(allowShoot == true){
            if(Input.GetKey(KeyCode.Space) && cooldownTimer >= levels.attackCooldown){
                cooldownTimer = 0;
                Shoot();

                AudioController audioController = FindAnyObjectByType<AudioController>();
                audioController.playAttackSound();
            }
        }
    }

    void Shoot(){
        animator.SetTrigger("Attack");

        if(currentRouteIndex == 0){
            Instantiate(projectilePrefabSide0, projectileSpawn.position, Quaternion.identity);
        }

        else if(currentRouteIndex == 2){
            Instantiate(projectilePrefabSide2, projectileSpawn.position, Quaternion.identity);
        }

        else if(currentRouteIndex == 1){
            Instantiate(projectilePrefabCenter, projectileSpawn.position, Quaternion.identity);
        }
    }
 
    public void DecreaseHealth(){
        health--;
        if(health >= 0 && health < healthBar.Length)
        {
            HeartController heartController = healthBar[health].GetComponent<HeartController>();
            heartController.StartAnimation();
        }

        EnemySpawn enemySpawn = FindAnyObjectByType<EnemySpawn>();
        StartCoroutine(enemySpawn.DelaySpawn(2));

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in allEnemies)
            Destroy(enemy);
        GameObject[] allSlime = GameObject.FindGameObjectsWithTag("Slime");
        foreach (GameObject slime in allSlime)
            Destroy(slime);
        


        DamageController takeDamage = FindAnyObjectByType<DamageController>();
        StartCoroutine(takeDamage.TakeDamageEffect(0.5f));
    }

    void GameOver(){
        animator.SetTrigger("Death");

        StartCoroutine(PauseGameAfterDelay(1.5f));
    }

    IEnumerator PauseGameAfterDelay(float delay){
        allowMove = false;
        allowShoot = false;
        yield return new WaitForSeconds(delay);

        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        ScoreCounter.SetActive(true);
        CanvasScore.SetActive(false);
    }
    
    IEnumerator ActivateHealthBars(){
        foreach (GameObject bar in healthBar){
            bar.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator MoveAfterDelay(){
        Levels levels = FindAnyObjectByType<Levels>();
        allowShoot = false;

        yield return new WaitForSeconds(levels.moveDelay);

        MoveToRoute();
        allowShoot = true;
    }
}
