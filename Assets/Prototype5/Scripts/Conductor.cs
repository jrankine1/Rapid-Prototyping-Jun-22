using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public enum GameType { Exploration, Music}

    public GameType gameType;

    public float songBPM;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;
    public AudioSource musicSource;
    public float firstBeatOffset;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        gameType = GameType.Exploration;
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
        gameType = GameType.Music;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Music"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                RhythmGame();
            }
        }
    }
}
