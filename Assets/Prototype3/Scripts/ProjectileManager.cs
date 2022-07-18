using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject projectileType;
    float spawnDelay = 1;
    

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rndSpawn = Random.Range(0, spawnPoints.Length);
            yield return new WaitForSeconds(1);
           Instantiate(projectileType, spawnPoints[i].position, spawnPoints[i].rotation); 
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnTargets());
        
    }
}
