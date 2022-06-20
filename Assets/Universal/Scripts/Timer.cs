using UnityEngine;

public class Timer : GameBehaviour<Timer>
{
    public enum TimerDirection { CountUp, CountDown}
    public TimerDirection timerDirection;
    bool isTiming = false;
    public float currentTime;

    // Update is called once per frame
    void Update()
    {
        if (isTiming)
        {
            if (timerDirection == TimerDirection.CountUp)
                currentTime += Time.deltaTime;
            else
                currentTime -= Time.deltaTime;
        }
            

    }

    /// <summary>
    /// Starts Timer from Zero and increments in real time
    /// </summary>
    /// <param name="_startTime">Optional value to start timer at. Defaults to zero</param>
    public void StartTimer(float _startTime = 0f)
    {
        isTiming = true;
        currentTime = _startTime;
    }

    public void ResumeTimer()
    {
        isTiming = true;
    }
    public void PauseTimer()
    {
        isTiming = false;
    }
    public void StopTimer()
    {
        isTiming = false;
    }

    /// <summary>
    /// Increments our timer a set amount
    /// </summary>
    /// <param name="_increment">The amount of increment</param>
    public void IncrementTimer(float _increment)
    {
        
            currentTime += _increment;
    }

    public void DecrementTimer(float _decrement)
    {
        
            currentTime -= _decrement;
    }

    public float GetTime()
    {
        return currentTime;
    }

    public bool IsTiming()
    {
        return isTiming;
    }

    /// <summary>
    /// Checks whether our time has expired or not
    /// </summary>
    /// <returns>True is timer is less than zero</returns>
    public bool TimeExpired()
    {
        return currentTime < 0f;
    }
}
