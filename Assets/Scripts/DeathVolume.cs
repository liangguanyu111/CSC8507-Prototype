using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathVolume : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.OnPlayerDie.Invoke();

        }
    }
}
