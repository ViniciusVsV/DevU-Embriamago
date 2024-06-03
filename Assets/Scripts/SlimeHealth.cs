using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour
{
    public int health;
    void Start()
    {
        health = 2;
        
    }

    // Update is called once per frame
    public void TakeDamage()
    {
        health--;
        if (health <= 0) {
            Destroy(gameObject);
            EnemyBehaviour enemy = gameObject.GetComponent<EnemyBehaviour>();
            enemy.Die();

            AudioController audioController = FindAnyObjectByType<AudioController>();
            audioController.playEnemyDeathSound();

            Score score = FindAnyObjectByType<Score>();
            score.AddScore();

                   
        }
    }
}
