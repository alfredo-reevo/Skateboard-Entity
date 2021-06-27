using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is the script that provides the skateboard with physics-based movement.


public class VehicleController : MonoBehaviour
{

    public KeyCode ExitKey = KeyCode.E;

    private vehicle boardController;



    private void Start()
    {
        boardController = GetComponent<vehicle>();
    }



    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        FRWheel.steerAngle = m_steeringAngle;
        FLWheel.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        FRWheel.motorTorque = m_verticalInput * motorForce;
        FLWheel.motorTorque = m_verticalInput * motorForce;
        BRWheel.motorTorque = m_verticalInput * motorForce;
        BLWheel.motorTorque = m_verticalInput * motorForce;
    }

    /*private void UpdateWheelPoses()
    {

    }
    */

    /*private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {

    }
    */
    
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        //UpdateWheelPoses();
    }


    private void Update()
    {
        if (Input.GetKeyDown(ExitKey))
        {
            boardController.Exit();
        }
    }

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider FRWheel, FLWheel;
    public WheelCollider BRWheel, BLWheel;
    //public Transform FRWheelT, FLWheelT;
    //public Transform BRWheelT, BLWheelT;
    public float maxSteerAngle = 30f;
    public float motorForce = 50f;
}
