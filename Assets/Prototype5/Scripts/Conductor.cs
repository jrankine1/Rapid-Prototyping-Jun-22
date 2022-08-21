using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public float songBPM;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;
    public AudioSource musicSource;
    public float firstBeatOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        songPositionInBeats = songPosition / secPerBeat;
    }

    public void RhythmGame()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBPM;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }
}
