using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour{
    public Animator animator;
    
    public float speed = 10f;
    public float lifetime = 0.2f;

    void Start(){
        Destroy(gameObject, lifetime);
    }

    void Update(){ 
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = other.gameObject.GetComponent<EnemyBehaviour>();
            enemy.Die();

            Destroy(gameObject);

            AudioController audioController = FindAnyObjectByType<AudioController>();
            audioController.playEnemyDeathSound();

            Score score = FindAnyObjectByType<Score>();
            score.AddScore();
        }
        else
        {
            Destroy(gameObject);
            SlimeHealth slimeHealth = FindAnyObjectByType<SlimeHealth>();
            slimeHealth.TakeDamage();
            
        }
    }
}
