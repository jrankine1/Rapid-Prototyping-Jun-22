using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PivotController : GameBehaviour
{
    public enum PivotDirection {Left, Right};
    public enum PivotStyle {Tween, Update};
    public Transform pivotPoint;
    public Transform pivotObject;
    public PivotStyle pivotStyle;
    public Ease ease;
    public bool snapPivot = true;
    public float pivotTweenTime = 0.4f;
    public float pivotRotation = 180f;
    public float pivotUpdateSpeed = 100f;
    public float moveSpeed = 1f;

    PivotDirection pivotDirection;

    
    
    
    void Update()
    {
        if (pivotStyle == PivotStyle.Tween)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                TweenPivot(PivotDirection.Left);
            if (Input.GetKeyDown(KeyCode.RightArrow))
                TweenPivot(PivotDirection.Right);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                UpdatePivot(PivotDirection.Left);
            if (Input.GetKey(KeyCode.RightArrow))
                UpdatePivot(PivotDirection.Right);
        }

       


    }

    void TweenPivot(PivotDirection _dir)
    {
        if (_dir == PivotDirection.Left)
        {
            transform.DOLocalRotate(new Vector3(0, pivotRotation, 0), pivotTweenTime).SetRelative(!snapPivot).SetEase(ease);
        }
        else
        {
            if (snapPivot)
                transform.DOLocalRotate(new Vector3(0, 0, 0), pivotTweenTime).SetRelative(!snapPivot).SetEase(ease);
            else
                transform.DOLocalRotate(new Vector3(0, -pivotRotation, 0), pivotTweenTime).SetRelative(!snapPivot).SetEase(ease);
        }
    }

    void UpdatePivot(PivotDirection _dir)
    {
        if (_dir == PivotDirection.Left)
            transform.Rotate(Vector3.up * Time.deltaTime * pivotUpdateSpeed);
        else
            transform.Rotate(-Vector3.up * Time.deltaTime * pivotUpdateSpeed);
    }

    
}
