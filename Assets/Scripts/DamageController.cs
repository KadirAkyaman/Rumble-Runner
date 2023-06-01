using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    ScoreController scoreController;
    [SerializeField] int damageAmount;
    void Start()
    {
        scoreController = GetComponent<ScoreController>();
    }

    void Update()
    {
        if (scoreController.score < 0)
        {
            scoreController.score = 1;
            scoreController.ScoreUpdate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            scoreController.score -= damageAmount;
            scoreController.ScoreUpdate();
        }
    }
}
