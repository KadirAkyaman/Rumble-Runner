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
    public int operatorNum;//1 = plus, 2 = minus, 3 = multiple, 4 = divide
    [SerializeField] Image image;
    void Start()
    {
        number = Random.Range(minNumber, maxNumber);
        numberText.text = number.ToString();
        operatorNum = Random.Range(0, 4);
        image.sprite = operators[operatorNum];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(numberText.text);
        }
    }
}
