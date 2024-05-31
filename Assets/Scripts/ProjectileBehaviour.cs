using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour{
    public float speed = 10f;
    public float lifetime = 0.2f;

    void Start(){
        Destroy(gameObject, lifetime);
    }

    void Update(){ 
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    } 

    void OnCollisionEnter(Collision collision){
        Destroy(collision.gameObject);
        Destroy(gameObject); 

        AudioController audioController = FindAnyObjectByType<AudioController>();
        audioController.playEnemyDeathSound();

        Score score = FindAnyObjectByType<Score>();
        score.AddScore();
    }
}
