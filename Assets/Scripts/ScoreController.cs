using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int score;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        score = 100;
        scoreText.text = score.ToString();
    }

    public void ScoreUpdate()
    {
        scoreText.text = score.ToString();
    }

}
