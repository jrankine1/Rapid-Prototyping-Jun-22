using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType { Platform, Door }

public class ObjectMove : MonoBehaviour
{
    public GameObject objectToMove;
    public bool platform;
    public bool door;
    public float posToMoveToX;
    public float posToMoveToY;
    public float posToMoveToZ;
    public List<GameObject> activtorsNotInUse;

    public ObjectType objectType;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.doorScore == 300)
        {
            ObstacleMove();
            StartCoroutine(DoorOpen());
        }
        if (GameManager.instance.platformScore == 300)
        {
            ObstacleMove();
            StartCoroutine(DoorOpen());
        }
        if (GameManager.instance.currentScore == 0)
        {
            StartCoroutine(DoorOpen());
        }






    }

    void ObstacleMove()
    {
        switch (objectType)
        {
            case ObjectType.Door:
                objectToMove.transform.position = new Vector3(posToMoveToX, posToMoveToY, posToMoveToZ);
                break;
            case ObjectType.Platform:

                objectToMove.transform.position = new Vector3(posToMoveToX, posToMoveToY, posToMoveToZ);
                break;
        }
    }

    IEnumerator DoorOpen()
    {
        if(objectType == ObjectType.Door)
        {
            activtorsNotInUse[0].SetActive(false);
            if (GameManager.instance.currentScore == 0)
            {
                activtorsNotInUse[0].SetActive(true);
            }
            yield return null;
        }

        if(objectType == ObjectType.Platform)
        {
            activtorsNotInUse[0].SetActive(false);
            if (GameManager.instance.currentScore == 0)
            {
                activtorsNotInUse[0].SetActive(true);
            }
            yield return null;
        }
        
    }
}
