using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }


    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    private float timer;
    private float timerMax;
    private float startIntensity;

    private void Awake()
    {
        Instance = this;

        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (timer < timerMax)
        {
            timer += Time.deltaTime;
            float amplitude = Mathf.Lerp(startIntensity, 0f, timer / timerMax);
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitude;
        }
    }

    public void ShakeCamera(float intensity, float timer)
    {
        this.timerMax = timer;
        this.timer = 0f;
        this.startIntensity = intensity;

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }
}
