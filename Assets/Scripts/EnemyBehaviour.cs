using UnityEngine;

public class EnemyBehaviour : MonoBehaviour{
    public float targetX;
    public float targetZ;
    public float targetY;

    private Transform target;
    
    void Start(){
        GameObject targetObject = new GameObject("Target");
        targetObject.transform.position = new Vector3(targetX, targetY , targetZ);

        target = targetObject.transform;
        Destroy(targetObject, 10f);
    }

    void Update(){
        Levels levels = FindAnyObjectByType<Levels>();
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, levels.enemySpeed * Time.deltaTime);

        transform.position = newPosition;

        if(transform.position.z <= -8.862){
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            if(player != null)
                player.DecreaseHealth();

            Destroy(gameObject);
        }
    }
}