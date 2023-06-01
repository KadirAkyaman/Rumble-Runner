using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PathCreation.Examples
{
    public class PlayerMovement : MonoBehaviour
    {
        float touchXDelta = 0;
        float newX = 0;
        [SerializeField] float xSpeed;
        [SerializeField] float limitX;


        PathFollower pathFollower;

        GameManager gameManager;

        Animator playerAnimator;

        [SerializeField] GameObject player;
        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            playerAnimator = GameObject.Find("Player").GetComponentInChildren<Animator>();
        }
        void Update()
        {
            if (!gameManager.isFinish)
            {
                SwipeCheck();
            }

        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Finish"))
            {
                Debug.Log("Finish");

                pathFollower = GameObject.Find("PlayerPath").GetComponent<PathFollower>();

                pathFollower.enabled = false;

                gameManager.isFinish = true;

                transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
                playerAnimator.SetBool("isFinish", true);

                Invoke("RestartGame", 5);
            }
        }
        void SwipeCheck()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)//Dokundurulup hareket ettiriliyorsa
            {
                touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
            }
            else if (Input.GetMouseButton(0))
            {
                touchXDelta = Input.GetAxis("Mouse X");
            }
            else
            {
                touchXDelta = 0;
            }
            newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
            newX = Mathf.Clamp(newX, -limitX, limitX);

            Vector3 newPos = new Vector3(newX, transform.position.y, transform.position.z);
            transform.position = newPos;
        }

        void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
