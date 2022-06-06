using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    /// <summary>
    /// Get's a random colour from all possible colours with an alpha of 1
    /// </summary>
    /// <returns>A random colour</returns>
    public Color GetRandomColor()
    {
        
        return new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
