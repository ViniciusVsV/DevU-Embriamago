using UnityEngine;

public class SpeedLinesController : MonoBehaviour{
    public GameObject speedLinesEffectHard;
    public GameObject speedLinesEffectInsane;
    public GameObject speedLinesEffectImpossible;

    void Start(){
        endSpeedLines(1);
        endSpeedLines(2);
        endSpeedLines(3);
    }

    public void startSpeedLines(int selector){
        if(selector == 1)
            speedLinesEffectHard.SetActive(true);
        else if(selector == 2)
            speedLinesEffectInsane.SetActive(true);
        else if(selector == 3)
            speedLinesEffectImpossible.SetActive(true);
    }

    public void endSpeedLines(int selector){
        speedLinesEffectHard.SetActive(false);

        if(selector == 1)
            speedLinesEffectHard.SetActive(false);
        else if(selector == 2)
            speedLinesEffectInsane.SetActive(false);
        else if(selector == 3)
            speedLinesEffectImpossible.SetActive(false);
    }
}
