using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public void Play_LeftFoot() 
    {
        AudioManager.instance.Play_FootL();
    }
    public void Play_RightFoot()
    {
        AudioManager.instance.Play_FootR();
    }
}
