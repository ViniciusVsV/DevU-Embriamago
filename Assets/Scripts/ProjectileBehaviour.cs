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
