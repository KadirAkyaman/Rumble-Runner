using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float touchXDelta = 0;
    float newX = 0;
    [SerializeField] float xSpeed;
    [SerializeField] float limitX;
    void Update()
    {
        SwipeCheck();
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
}
