using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    void Awake(){
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Start(){
        StopShake();
        IncreaseFOV(60f);
    }

    public void ShakeCamera(float shakeIntensity){
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = shakeIntensity;
    }

    public void StopShake(){
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
    }

    public void IncreaseFOV(float newFOV){
        CinemachineVirtualCamera vCam = CinemachineVirtualCamera.GetComponent<CinemachineVirtualCamera>();
        vCam.m_Lens.FieldOfView = newFOV;
    }
}