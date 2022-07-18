using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed = 1f;
    public float playerHealth = 3;

    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-6, 5, -51);
            
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(0, 5, -51);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(6, 5, -51);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = new Vector3(0, 5, -51);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Camera.main.DOShakePosition(moveSpeed, 0.4f);
            playerHealth -= 1;
        }
    }
}
