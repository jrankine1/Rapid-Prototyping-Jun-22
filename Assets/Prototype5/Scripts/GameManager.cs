using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentScore;
    public int scorePerNote = 100;
    public int doorScore;
    public int platformScore;
    public ObjectMove objectMove;
    
   

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NoteHit()
    {
        currentScore += scorePerNote;
        switch(objectMove.objectType)
        {
            case (ObjectType.Door):
                doorScore = currentScore;
                
                break;
            case (ObjectType.Platform):
                platformScore = currentScore;
                break;
        }

        
    }

    
}
