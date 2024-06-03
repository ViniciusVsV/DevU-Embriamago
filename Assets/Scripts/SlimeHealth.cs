using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour
{
    public int health = 2;

   
       public void TakeDamage()
        {
        health--;
            if(health <= 0)
            {
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
