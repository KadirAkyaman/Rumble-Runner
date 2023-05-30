using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
    public class GameManager : MonoBehaviour
    {
        PathFollower pathFollower;
        [SerializeField] GameObject player;

        //Animator
        [SerializeField] Animator playerAnimator;

        //Rotation
        Quaternion startRotation;
        void Start()
        {
            pathFollower = GameObject.Find("PlayerPath").GetComponent<PathFollower>();
            pathFollower.enabled = false;

            //startRotation = Quaternion.Euler(0f, 180f, 0f) * transform.rotation;
            //player.transform.rotation = startRotation;
        }

        void Update()
        {
            PathFollower();
        }

        void PathFollower()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(RotatePlayer());
            }
        }

        IEnumerator RotatePlayer()
        {
            
            yield return new WaitForSeconds(0.5f);
            playerAnimator.SetBool("isStart", true);
            pathFollower.enabled = true;
        }
    }
}
