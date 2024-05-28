using UnityEngine;

public class EnemyBehaviour : MonoBehaviour{
    public float targetX;
    public float targetZ;
    public float targetY;
    private float speed = 8f;

    private Transform target;
    
    void Start(){
        GameObject targetObject = new GameObject("Target");
        targetObject.transform.position = new Vector3(targetX, targetY , targetZ);

        target = targetObject.transform;
        Destroy(targetObject, 10f);
    }

    void Update(){
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        transform.position = newPosition;

        if(transform.position.z <= -9.772){
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            if(player != null)
                player.DecreaseHealth();

            Destroy(gameObject);
        }
    }

    public void setSpeed(float newSpeed){
        speed = newSpeed;
    }
}