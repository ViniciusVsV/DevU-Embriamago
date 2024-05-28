using UnityEngine;

public class ProjectileBehaviourSides : MonoBehaviour{
    public float targetX;
    public float targetZ;
    public float targetY;
    public float speed = 10f;
    public float lifetime = 2f;

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

    void OnCollisionEnter(Collision collision){
        Destroy(collision.gameObject);
        Destroy(gameObject); 
    }
}
