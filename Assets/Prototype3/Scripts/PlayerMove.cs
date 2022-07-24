using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed = 1f;
    public float playerHealth = 3;

    

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOverProto3");
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
