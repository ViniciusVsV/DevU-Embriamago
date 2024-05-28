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
    }

    void UpdateScoreText(){
        scoreText.text = "Score: " + scoreValue.ToString();
    }
}