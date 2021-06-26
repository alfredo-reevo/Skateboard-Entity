using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicle : MonoBehaviour
{
    public Transform player;

    public bool vehicleActive;
    bool isInTransition;
    public Transform seatPoint;
    public Vector3 sittingoffset;
    public Transform exitPoint;
    [Space]
    public float transitionSpeed = 0.2f;

    void Update()
    {
        if (vehicleActive && isInTransition) Exit();
        else if (!vehicleActive && isInTransition) Enter();

        if (Input.GetKeyDown(KeyCode.E))
        {
            isInTransition = true;
        }

    }

    private void Enter()
    {
        //Disable components
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<PlayerMovement>().enabled = false;

        //Move obj to designated seat
        player.position = Vector3.Lerp(player.position, seatPoint.position + sittingoffset, transitionSpeed);
        player.rotation = Quaternion.Slerp(player.rotation, seatPoint.rotation, transitionSpeed);

        /*Player animation to sitting (will implement later)
         player.GetComponentInChildren<Animator>().SetBool("Sitting", true);
        */

        //Set board camera to active
    
        // Reset - check
        if (player.position == seatPoint.position + sittingoffset)
        {
            isInTransition = false;
            vehicleActive = true;
        }
    }

    void Exit()
    {
        //Move obj to designated exit point
        player.position = Vector3.Lerp(player.position, exitPoint.position, transitionSpeed);

        //Set obj animation to idle (will implement later)
        //player.GetComponentInChildren<Animator>().SetBool("Sitting", false);

        //Reset - check
        if (player.position == exitPoint.position)
        {
            isInTransition = false; 
            vehicleActive = false;
        }

        //Enable components
        player.GetComponent<CapsuleCollider>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}