using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script provides the child camera to look and move in respect to the board.


public class BoardCameraController : MonoBehaviour
{


    public void LookAtTarget()
    {
        Vector3 _lookDirection = boardtrans.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }
    
    public void MoveToTarget()
    {
        Vector3 _targetPos = boardtrans.position + boardtrans.forward * offset.z + boardtrans.right * offset.x + boardtrans.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }


    public Transform boardtrans;
    public Vector3 offset;
    public float followSpeed = 10f;
    public float lookSpeed = 10f;

}
