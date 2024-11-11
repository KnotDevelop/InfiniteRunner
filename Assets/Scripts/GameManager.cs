using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int targetFrameRate = 60;
    public bool isPlaying = false;
    public bool isPaused = false;
    [SerializeField] Player player;
    int score = 0;

    private void Start()
    {
        AudioManager.instance.Play_BG();
    }
    public int GetScore() 
    {
        return score;
    }
    public void TakeScore()
    {
        score++;
        UIManager.Instance.UpdateScoreText(score);
        PlatformManager.instance.SetSpeed(score);
    }
    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        isPlaying = true;
        player.rb.useGravity = true;
        PlayerAnimationManager.instance.Play_Run();
        PlatformManager.instance.SetSpeed(score);
    }
    public void GameOver()
    {
        isPlaying = false;
        PlayerAnimationManager.instance.Play_Idle();
        UIManager _um = UIManager.Instance;
        StartCoroutine(_um.DelayUI(()=> {
            _um.FinishPanel_Switch(true);
            AudioManager.instance.Stop_BG();
            AudioManager.instance.Play_GameOver();
        }, 1));
    }
    public void Puase()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        UIManager.Instance.PuasePanel_Switch(true);
    }
    public void Unpuase()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        UIManager.Instance.PuasePanel_Switch(false);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("InfiniteRunner");
    }
}
