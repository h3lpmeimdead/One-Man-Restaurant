using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
     private CinemachineVirtualCamera vcCamera;
     private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        vcCamera = GetComponent<CinemachineVirtualCamera>();
        noise = vcCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void ShakeCamera(float intensity)
    {
        noise.m_AmplitudeGain = intensity;
        //StartCoroutine(WaitTime(shakeTime));
    }
    IEnumerator WaitTime(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        ResetIntensity();

    }
    void ResetIntensity()
    {
        noise.m_AmplitudeGain = 0f;
    }
}
