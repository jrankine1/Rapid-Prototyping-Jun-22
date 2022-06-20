using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : GameBehaviour<UIManager>
{
    public TMP_Text bestTimeText;
    public TMP_Text currentTimeText;

    public void UpdateCurrentTime(float _time)
    {
        currentTimeText.text = "Current Time: " + _time.ToString("F2");
    }

    public void UpdateBestTime(float _time, bool _firsTime = false)
    {
        if(_firsTime)
        {
            bestTimeText.text = "Best Time Not Yet Set";
        }
        else
        {
            bestTimeText.text = "Best Time: " + _time.ToString("F2");
        }
        
    }
    
}
