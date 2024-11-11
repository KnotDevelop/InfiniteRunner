using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bg;
    public AudioSource click;
    public AudioSource footL;
    public AudioSource footR;
    public AudioSource gameOver;
    public AudioSource swipe;

    private void Awake()
    {
        instance = this;
    }
    public void Play_BG()
    {
        bg.Play();
    }
    public void Stop_BG()
    {
        bg.Stop();
    }
    public void Play_Click()
    {
        click.Play();
    }
    public void Play_FootL()
    {
        footL.Play();
    }
    public void Play_FootR()
    {
        footR.Play();
    }
    public void Play_GameOver()
    {
        gameOver.Play();
    }
    public void Play_Swipe()
    {
        swipe.Play();
    }
    public void OpenAllAudio()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioVolume>().OpenSound();
        }
    }
    public void CloseAllAudio()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioVolume>().CloseSound();
        }
    }
}
