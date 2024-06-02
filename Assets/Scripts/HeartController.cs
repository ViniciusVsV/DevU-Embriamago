using UnityEngine;

public class HeartController : MonoBehaviour
{
    public Animator animator;
    public bool vibrate = false;
    private Vector3 originalPosition;

    void Start(){
        // Armazena a posição original do objeto
        originalPosition = transform.localPosition;
    }

    void Update(){
        if(vibrate){
            var speed = 5.0f;
            var intensity = 0.1f;
            
            // Calcula a nova posição com base na posição original e na vibração
            Vector3 newPosition = originalPosition + intensity * new Vector3(
                Mathf.PerlinNoise(speed * Time.time, 0) - 0.5f,
                Mathf.PerlinNoise(speed * Time.time, 1) - 0.5f,
                Mathf.PerlinNoise(speed * Time.time, 2) - 0.5f);
            
            transform.localPosition = newPosition;
        }
    }

    public void StartAnimation(){
        animator.SetTrigger("Lost");
    }
}