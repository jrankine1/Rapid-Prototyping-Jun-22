using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
   
    float movementSpeed = 1f;


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -50 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.DOShakePosition(movementSpeed, 0.4f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
