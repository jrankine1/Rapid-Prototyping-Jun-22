using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PivotController : GameBehaviour
{
    public enum PivotDirection { Left, Right};
    public Transform pivotPoint;
    public Transform pivotObject;
    public float pivotTime = 0.4f;

    PivotDirection pivotDirection;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePivot(PivotDirection _dir)
    {
        
    }
}
