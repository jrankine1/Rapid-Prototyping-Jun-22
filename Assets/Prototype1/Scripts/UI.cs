using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UI : GameBehaviour
{
    public float startValue = 30;
    public float toValue;
    public TMP_Text timeText;

    public void Start()
    {
        
        _TIMER.StartTimer(30f);

    }



    private void Update()
    {
        if (_TIMER.TimeExpired())
        {
            SceneManager.LoadScene("GameOver");
        }

        timeText.text = "Time: " + _TIMER.GetTime().ToString("F2");
    }

    


}
