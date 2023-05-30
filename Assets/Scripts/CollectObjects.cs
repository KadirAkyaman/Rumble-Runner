using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Steak"))
        {
            Debug.Log("Steak");
            Destroy(other.gameObject);
        }
    }
}
