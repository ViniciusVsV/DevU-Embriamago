using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBehaviourSides : MonoBehaviour {
    public Animator animator;

    public float targetX;
    public float targetZ;
    public float targetY;
    public float speed = 10f;
    public float lifetime = 2f;
    public int health = 0;

    private Transform target;

    void Start() {
        Destroy(gameObject, lifetime);

        GameObject targetObject = new GameObject("Target");
        targetObject.transform.position = new Vector3(targetX, targetY, targetZ);

        target = targetObject.transform;
        Destroy(targetObject, lifetime);
    }

    void Update() {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        transform.position = newPosition;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Slime")){
            EnemyBehaviour enemy = other.gameObject.GetComponent<EnemyBehaviour>();
            enemy.TakeDamage();

            Destroy(gameObject);
        }
    }
}
