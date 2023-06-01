using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    //Score Controller
    public ScoreController scoreController;

    private void Start()
    {
        scoreController = GetComponent<ScoreController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Steak"))
        {
            scoreController.score += 5;
            scoreController.ScoreUpdate();
            Destroy(other.gameObject);
        }
    }
}
