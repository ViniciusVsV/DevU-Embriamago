using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour{
    public Animator animator;

    public float targetX;
    public float targetZ;
    public float targetY;

    private Transform target;
    public bool isDying = false;
    
    void Start(){
        GameObject targetObject = new GameObject("Target");
        targetObject.transform.position = new Vector3(targetX, targetY , targetZ);

        target = targetObject.transform;
        Destroy(targetObject, 10f);
    }

    void Update(){
        if(isDying == false){
            Levels levels = FindAnyObjectByType<Levels>();
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, levels.enemySpeed * Time.deltaTime);
            transform.position = newPosition;

            if(transform.position.z <= -8.862){
                PlayerMovement player = FindObjectOfType<PlayerMovement>();
                player.DecreaseHealth();

                AudioController audioController = FindAnyObjectByType<AudioController>();
                audioController.playHitSound();

                Destroy(gameObject);
            }
        }
    }

    public void Die(){
        if (!isDying) {
            animator.SetTrigger("Death");
            isDying = true;

            Collider collider = GetComponent<Collider>();
            if(collider != null){
                collider.enabled = false;
            }

            Destroy(gameObject, 0.4f);
        }
    }
}