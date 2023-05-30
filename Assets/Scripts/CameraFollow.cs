using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float sSpeed = 10;
    [SerializeField] Vector3 distance;
    public Transform lookTarget;
    private void LateUpdate()
    {
        Vector3 dPos = target.position + distance;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }
}
