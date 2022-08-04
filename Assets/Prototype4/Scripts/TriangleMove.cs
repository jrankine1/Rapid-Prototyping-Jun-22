using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMove : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 90));

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -90));

        }
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    transform.Rotate(new Vector3(0, 0, 180));

        //}

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    transform.Rotate(new Vector3(0, 0, 0));

        //}
    }
}
