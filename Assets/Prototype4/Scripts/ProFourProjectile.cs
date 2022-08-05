using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProFourProjectile : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, 1, 0 * Time.deltaTime);
    }
}
