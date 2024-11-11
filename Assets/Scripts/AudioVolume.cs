using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] float volume;
    public float volumeMultiplier;

    private void Start()
    {
        volume = GetComponent<AudioSource>().volume;
        OpenSound();
        //CloseSound();
    }
    public void OpenSound()
    {
        volumeMultiplier = 1.0f;
        SetVolume();
    }
    public void CloseSound()
    {
        volumeMultiplier = 0.0f;
        SetVolume();
    }
    public void SetVolume()
    {
        GetComponent<AudioSource>().volume = volume * volumeMultiplier;
    }
}
