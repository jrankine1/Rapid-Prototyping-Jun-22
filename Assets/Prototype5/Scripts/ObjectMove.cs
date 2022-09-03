using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public GameObject objectToMove;
    public bool platform;
    public bool door;
    public float posToMoveToX;
    public float posToMoveToY;
    public float posToMoveToZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentScore == 500 && platform == true)
        {
            objectToMove.transform.position = new Vector3(posToMoveToX, posToMoveToY, posToMoveToZ);
        }
        if (GameManager.instance.currentScore == 500 && door == true)
        {
            objectToMove.transform.position = new Vector3(posToMoveToX, posToMoveToY, posToMoveToZ);
        }
    }
}
