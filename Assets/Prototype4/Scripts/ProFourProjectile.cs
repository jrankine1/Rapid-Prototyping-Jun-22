using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProFourProjectile : GameBehaviour
{
    
    
    private void OnCollisionEnter(Collision collision)
    {
        _EQ.CheckNumber(collision.gameObject.GetComponent<TMP_Text>().text);
        collision.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
