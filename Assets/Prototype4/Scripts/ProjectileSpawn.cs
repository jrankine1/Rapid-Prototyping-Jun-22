using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject projectileType;
    float spawnDelay = 1;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(SpawnTargets());
        }
        
    }

    IEnumerator SpawnTargets()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rndSpawn = Random.Range(0, spawnPoints.Length);
            yield return new WaitForSeconds(1);
            Instantiate(projectileType, spawnPoints[i].position, spawnPoints[i].rotation);
        }
        
        

    }
}
