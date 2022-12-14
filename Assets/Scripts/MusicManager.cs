using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static SoundManager;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }


    private AudioSource audioSource;
    private float volume = .5f;

    private void Awake()
    {
        Instance = this;

        volume = PlayerPrefs.GetFloat("musicVolume", .5f);

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    public void IncreaseVolume()
    {
        volume += .1f;
        volume = Mathf.Clamp01(volume);

        audioSource.volume = volume;

        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void DecreaseVolume()
    {
        volume -= .1f;
        volume = Mathf.Clamp01(volume);

        audioSource.volume = volume;

        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public float GetVolume()
    {
        return volume;
    }
}
