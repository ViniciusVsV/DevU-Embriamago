using UnityEngine;
using Cinemachine;
using System.Collections;

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

public class MoveCamera : MonoBehaviour{
    public IEnumerator MoveCameraBack(Vector3 offset, float duration){
        Camera mainCamera = Camera.main;
        Vector3 startPosition = mainCamera.transform.position;
        Vector3 endPosition = startPosition + offset;
        float elapsedTime = 0f;

        while (elapsedTime < duration){
            mainCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = endPosition;
    }
}
