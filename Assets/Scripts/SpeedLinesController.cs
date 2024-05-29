using UnityEngine;

public class SpeedLinesController : MonoBehaviour{
    public GameObject speedLinesEffect;

    void Start(){
        endSpeedLines();
    }

    public void startSpeedLines(){
        Instantiate(speedLinesEffect, transform.position, Quaternion.identity);
    }

    public void endSpeedLines(){
        speedLinesEffect.SetActive(false);
    }
}
