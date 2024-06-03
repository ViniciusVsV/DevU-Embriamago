using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour{
    public Animator animator;
    
    public float speed = 10f;
    public float lifetime = 2f;
  

    void Start(){
        Destroy(gameObject, lifetime);
    }

    void Update(){ 
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Slime")){
            EnemyBehaviour enemy = other.gameObject.GetComponent<EnemyBehaviour>();
            enemy.TakeDamage();

            Destroy(gameObject);
        }
    }
}