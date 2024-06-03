using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextMenuGameOver;

    public int scoreValue;

    void Start(){
        scoreValue = 0;
        UpdateScoreText();
    }

    public void AddScore(){
        scoreValue += 100;
        UpdateScoreText();

        Levels levels = FindAnyObjectByType<Levels>();

        if(scoreValue >= 500 && scoreValue <= 700){
            levels.levelTransition(1);
        }
        else if(scoreValue >= 3500 && scoreValue <= 3700){
            levels.levelTransition(2);
        }
        else if(scoreValue >= 10000 && scoreValue <= 10200)
        {
            levels.levelTransition(3);
        }
        else if(scoreValue >= 30000 && scoreValue <= 30200)
        {
            levels.levelTransition(4);
        }
        else if(scoreValue >= 100000 && scoreValue <= 100200)
        {
            levels.levelTransition(5);
        }
    }

   void UpdateScoreText(){
        scoreText.text = "" + scoreValue.ToString();
        scoreTextMenuGameOver.text = "" + scoreValue.ToString();
    }

    public int getScore(){
        return scoreValue;
    }
}