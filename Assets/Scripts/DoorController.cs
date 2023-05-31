using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DoorController : MonoBehaviour
{
    public int number;
    [SerializeField] int minNumber;
    [SerializeField] int maxNumber;
    [SerializeField] TextMeshProUGUI numberText;
    [SerializeField] List<Sprite> operators;
    public int operatorNum;//0 = plus, 1 = minus, 2 = multiple, 3 = divide
    [SerializeField] Image image;

    //Score Controller
    public ScoreController scoreController;
    void Start()
    {
        number = Random.Range(minNumber, maxNumber);
        numberText.text = number.ToString();
        operatorNum = Random.Range(0, 4);
        image.sprite = operators[operatorNum];

        scoreController = GameObject.Find("PlayerPath").GetComponentInChildren<ScoreController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (operatorNum == 0)
            {
                scoreController.score += number;
                scoreController.ScoreUpdate();
            }
            else if (operatorNum == 1)
            {
                if (scoreController.score<=number)
                {
                    scoreController.score = 1;
                    scoreController.ScoreUpdate();
                }
                else
                {
                    scoreController.score -= number;
                    scoreController.ScoreUpdate();
                }
            }
            else if (operatorNum == 2)
            {
                scoreController.score *= number;
                scoreController.ScoreUpdate();
            }
            else if (operatorNum == 3)
            {
                scoreController.score /= number;
                if (scoreController.score<=0)
                {
                    scoreController.score = 1;
                    scoreController.ScoreUpdate();
                }
                else
                {
                    scoreController.ScoreUpdate();
                }
            }
        }
    }
}
