using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerMovement : GameBehaviour
{
    private Rigidbody playerRb;
    public int playerLives = 3;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;
    
   
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * fowardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }

        if (other.CompareTag("Border"))
        {
            playerLives -= 1;
            transform.position = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }

        
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    

}
