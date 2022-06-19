using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public float startValue = 30;
    public float toValue;
    public TMP_Text timeText;

    

    private void Update()
    {
        timeText.text = "Time: " + startValue.ToString("F2");
        CountDown();
        //if (startValue <= 0)
        //{
        //    SceneManager.LoadScene("GameOver");
        //}
    }

    void CountDown()
    {
        startValue -= Time.deltaTime;
    }
}
