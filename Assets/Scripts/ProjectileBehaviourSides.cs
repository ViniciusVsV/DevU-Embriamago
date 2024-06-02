using UnityEngine;

public class ProjectileBehaviourSides : MonoBehaviour{
    public Animator animator;

    public float targetX;
    public float targetZ;
    public float targetY;
    public float speed = 10f;
    public float lifetime = 0.2f;

    private Transform target;

    void Start(){
        Destroy(gameObject, lifetime);

        GameObject targetObject = new GameObject("Target");
        targetObject.transform.position = new Vector3(targetX, targetY , targetZ);

        target = targetObject.transform;
        Destroy(targetObject, lifetime);
    }

    void Update(){ 
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        transform.position = newPosition;
    } 

    void OnTriggerEnter(Collider obj){
        if(obj.gameObject.CompareTag("Enemy")){
            EnemyBehaviour enemy = obj.gameObject.GetComponent<EnemyBehaviour>();
            enemy.Die();

            Destroy(gameObject); 

            AudioController audioController = FindAnyObjectByType<AudioController>();
            audioController.playEnemyDeathSound();

            Score score = FindAnyObjectByType<Score>();
            score.AddScore();
        }else{

        }
    }
}
