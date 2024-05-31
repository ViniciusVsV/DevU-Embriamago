using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBehaviourSides : MonoBehaviour{
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

    void OnCollisionEnter(Collision collision)
    {
        Score score = FindObjectOfType<Score>();
        AudioController audioController = FindObjectOfType<AudioController>();

        if (audioController != null)
        {
            audioController.playEnemyDeathSound();
        }


        //Reduz a pontuação em 500 caso acerte civil
        if (collision.gameObject.tag == "Civil")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            score.ReduceScore();
        }
        else
        {
            //Adiciona 100 pontos caso acerte inimigo
            if (score != null)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);

                score.AddScore();
            }
        }
    }
}
