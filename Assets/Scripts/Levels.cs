using System.Xml.Serialization;
using UnityEngine;

public class Levels : MonoBehaviour{
    private int currentScore = 0;
    EnemySpawn enemySpawn = FindAnyObjectByType<EnemySpawn>();
    EnemyBehaviour enemyBehaviour = FindAnyObjectByType<EnemyBehaviour>();
    
    void Start(){
        setDificultyStart();
    }

    
    void Update(){
        Score score = FindAnyObjectByType<Score>();
        currentScore = score.getScore();

        if(currentScore >= 500 && currentScore < 1500)
            setDificultyEasy();


        if(currentScore >= 1500 && currentScore < 3000)
            setDificultyModerate();

        if(currentScore >= 3000 && currentScore < 5000)
            setDificultyHard();

        if(currentScore >= 5000)
            setDificultyInsane();
    }

    void setDificultyStart(){

    }

    void setDificultyEasy(){

    }

    void setDificultyModerate(){

    }
    
    void setDificultyHard(){

    }

    void setDificultyInsane(){

    }
}
