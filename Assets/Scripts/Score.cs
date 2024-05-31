using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour{
    public TextMeshProUGUI scoreText;

    private int scoreValue;

    void Start(){
        scoreValue = 0;
        UpdateScoreText();
    }

    public void AddScore(){
        scoreValue += 100;
        UpdateScoreText();

        Levels levels = FindAnyObjectByType<Levels>();

        if(scoreValue == 500){
            levels.levelTransition(1);
        }
        else if(scoreValue == 3500){
            levels.levelTransition(2);
        }
        else if(scoreValue == 10000){
            levels.levelTransition(3);
        }
        else if(scoreValue == 30000){
            levels.levelTransition(4);
        }
        else if(scoreValue == 100000){
            levels.levelTransition(5);
        }
    }

    void UpdateScoreText(){
        scoreText.text = "" + scoreValue.ToString();
    }

    public int getScore(){
        return scoreValue;
    }
}