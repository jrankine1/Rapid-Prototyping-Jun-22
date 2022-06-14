using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TweenNumber : GameBehaviour
{
    float startValue = 0f;
    float toValue = 10;
    public TMP_Text scoreText;
    public Ease ease;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TweenScore();
        }
    }

    void TweenScore()
    {
        DOTween.To(() => startValue, x => startValue = x, toValue, 1).SetEase(ease).OnUpdate(() =>
        {
            scoreText.text = "Score: " + startValue.ToString("F2");
        });
    }
}
