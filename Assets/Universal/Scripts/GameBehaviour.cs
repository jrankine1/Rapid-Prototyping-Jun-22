using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameBehaviour : MonoBehaviour
{
    /// <summary>
    /// Get's a random colour from all possible colours with an alpha of 1
    /// </summary>
    /// <returns>A random colour</returns>
    public Color GetRandomColor()
    {
        
        return new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
    /// <summary>
    /// Fade in Canvas group
    /// </summary>
    /// <param name="cvg">The canvas group to fade</param>
    /// <param name="tweenTime">optional time to tween</param>
    public void FadeInCanvas(CanvasGroup cvg, float tweenTime = 1f)
    {
        cvg.DOFade(1, tweenTime);
        cvg.interactable = true;
        cvg.blocksRaycasts = true;
    }

    /// <summary>
    /// Fades out Canvas Group
    /// </summary>
    /// <param name="cvg">The canvas group to fade</param>
    /// <param name="tweenTime">optional time to tween</param>
    public void FadeOutCanvas(CanvasGroup cvg, float tweenTime = 1f)
    {
        cvg.DOFade(0, tweenTime).SetEase(Ease.InExpo);
        cvg.interactable = false;
        cvg.blocksRaycasts = false;
    }
}
