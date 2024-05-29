using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float shakeIntensity = 1f;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    void Awake(){
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Start(){
        StopShake();
    }

    public void ShakeCamera(){
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = shakeIntensity;
    }

    public void StopShake(){
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
    }
}
