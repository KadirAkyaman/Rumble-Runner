using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public int score;
    [SerializeField] int minScore;
    [SerializeField] int maxScore;
    [SerializeField] TextMeshProUGUI scoreText;

    //Damage Amount
    [SerializeField] int damageAmount;

    //Score Controller
    ScoreController scoreController;


    Rigidbody rigidbody;
    [SerializeField] float forceAmount;

    Transform playerPos;


    public Animator enemyAnimator;





    void Start()
    {
        score = Random.Range(minScore, maxScore);
        scoreText.text = score.ToString();

        enemyAnimator = GetComponentInChildren<Animator>();

        rigidbody = GetComponent<Rigidbody>();
        //Score Controller
        scoreController = GameObject.Find("PlayerPath").GetComponentInChildren<ScoreController>();
    }

    private void Update()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (score >= scoreController.score)
            {

                if (scoreController.score>damageAmount)
                {
                    scoreController.score -= damageAmount;
                    scoreController.ScoreUpdate();
                }

                

                if (transform.position.x > playerPos.position.x)
                {
                    rigidbody.AddForce(new Vector3(0.3f * forceAmount * Time.deltaTime, 0, 1 * forceAmount * Time.deltaTime), ForceMode.Impulse);
                    rigidbody.useGravity = true;

                    enemyAnimator.SetBool("isDead", true);
                }
                else
                {
                    rigidbody.AddForce(new Vector3(-0.3f * forceAmount * Time.deltaTime, 0, 1 * forceAmount * Time.deltaTime), ForceMode.Impulse);
                    rigidbody.useGravity = true;

                    enemyAnimator.SetBool("isDead", true);
                }
            }

            else
            {
                if (transform.position.x > playerPos.position.x)
                {
                    rigidbody.AddForce(new Vector3(0.3f * forceAmount * Time.deltaTime, 0, 1 * forceAmount * Time.deltaTime), ForceMode.Impulse);
                    rigidbody.useGravity = true;

                    enemyAnimator.SetBool("isDead", true);
                }
                else
                {
                    rigidbody.AddForce(new Vector3(-0.3f * forceAmount * Time.deltaTime, 0, 1 * forceAmount * Time.deltaTime), ForceMode.Impulse);
                    rigidbody.useGravity = true;

                    enemyAnimator.SetBool("isDead", true);
                }
                //
            }
        }
    }
}
