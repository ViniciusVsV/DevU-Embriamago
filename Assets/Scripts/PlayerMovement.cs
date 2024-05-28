using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Transform[] routes;
    public GameObject projectilePrefabCenter;
    public GameObject projectilePrefabSide0;
    public GameObject projectilePrefabSide2;
    public Transform projectileSpawn;

    private int currentRouteIndex;
    private float attackCooldown = 0.5f;
    private float cooldownTimer = 0.5f;

    public int health = 3;

    void Start(){
        currentRouteIndex = 1;
        Debug.Log("O jogo começou!");
    }

    
    void Update(){
        cooldownTimer += Time.deltaTime;

        HandleMovement();
        HandleShooting();

        if(health == 0)
            Debug.Log("Morreu zé");
    }

    //Mecânica de Movimento do Player
    void HandleMovement(){
        if(Input.GetKeyDown(KeyCode.A) && currentRouteIndex > 0){
            currentRouteIndex--;
            MoveToRoute();
        }

        else if(Input.GetKeyDown(KeyCode.D) && currentRouteIndex < 2){
            currentRouteIndex++;
            MoveToRoute();
        }
    }

    void MoveToRoute(){
        transform.position = new Vector3(routes[currentRouteIndex].position.x, transform.position.y, transform.position.z);
    }

    //Mecânica de Ataque
    void HandleShooting(){
        if((Input.GetKeyDown(KeyCode.Space) && cooldownTimer >= attackCooldown) || (Input.GetKeyDown(KeyCode.Mouse0) && cooldownTimer >= attackCooldown)){
            cooldownTimer = 0;
            Shoot();
        }
    }

    void Shoot(){
        if(currentRouteIndex == 0)
            Instantiate(projectilePrefabSide0, projectileSpawn.position, Quaternion.identity);

        else if(currentRouteIndex == 2)
            Instantiate(projectilePrefabSide2, projectileSpawn.position, Quaternion.identity);

        else if(currentRouteIndex == 1)
            Instantiate(projectilePrefabCenter, projectileSpawn.position, Quaternion.identity);
    }
    
}
