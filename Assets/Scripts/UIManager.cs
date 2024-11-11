using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI finishScore_text;
    [SerializeField] GameObject puase_panel;
    [SerializeField] GameObject fisnish_panel;

    [SerializeField] GameObject audio_btn;
    [SerializeField] GameObject audioMute_btn;
    public bool isAudio = true;

    private void Awake()
    {
        Instance = this;
    }
    public void AudioButton_Switch()
    {
        if (isAudio)
        {
            audio_btn.SetActive(false);
            audioMute_btn.SetActive(true);
            AudioManager.instance.CloseAllAudio();
            isAudio = false;
        }
        else
        {
            audio_btn.SetActive(true);
            audioMute_btn.SetActive(false);
            AudioManager.instance.OpenAllAudio();
            isAudio = true;
        }
    }
    private void Start()
    {
        UpdateScoreText(0);
    }
    public void UpdateScoreText(int _score)
    {
        score_text.text = _score.ToString();
        finishScore_text.text = _score.ToString();
    }
    public void PuasePanel_Switch(bool _result)
    {
        puase_panel.SetActive(_result);
    }
    public void FinishPanel_Switch(bool _result)
    {
        fisnish_panel.SetActive(_result);
    }
    public IEnumerator DelayUI(Action callback, float delay) 
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
