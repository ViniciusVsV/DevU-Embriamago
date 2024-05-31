using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CivilBehaviour : MonoBehaviour
{
    public float targetX;
    public float targetZ;
    public float targetY;


    private Transform target;

    void Start()
    {
        GameObject targetObject = new GameObject("Target");
        targetObject.transform.position = new Vector3(targetX, targetY, targetZ);

        target = targetObject.transform;
        Destroy(targetObject, 10f);
    }

    void Update()
    {
        Levels levels = FindAnyObjectByType<Levels>();
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, levels.enemySpeed * Time.deltaTime);
        Score score = FindAnyObjectByType<Score>();
        transform.position = newPosition;
        
        if (transform.position.z <= -8.862)
        {
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            if (player != null)
                score.AddScore();
                score.AddScore();
                score.AddScore();
            Destroy(gameObject);
        }



    }


}