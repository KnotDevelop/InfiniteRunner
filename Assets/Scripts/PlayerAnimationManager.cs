using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public static PlayerAnimationManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void Play_Idle()
    {
        transform.GetChild(0).GetComponent<Animator>().SetBool("isRun", false);
    }
    public void Play_Run()
    {
        transform.GetChild(0).GetComponent<Animator>().SetBool("isRun", true);
    }
}
