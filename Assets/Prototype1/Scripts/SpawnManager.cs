using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform[] xBounds;
    [SerializeField] Transform[] zBounds;
    [SerializeField] float startUpTime;
    [SerializeField] float spawnTime;

    private void Awake()
    {
        InvokeRepeating("Randomizer", startUpTime, spawnTime);
    }

    public void Randomizer()
    {
        GameObject spawnedObject = Instantiate(prefab, new Vector3(Random.Range(xBounds[0].position.x, xBounds[1].position.x), 0, Random.Range(zBounds[0].position.z, zBounds[1].position.z)), Quaternion.identity);
    }
}
