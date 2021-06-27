using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is the script that controls the mount/dismount of the skateboard.


public class vehicle : MonoBehaviour
{
    public Transform player;
    public bool vehicleActive;
    public bool isInTransition;
    public Transform seatPoint;
    public Vector3 sittingoffset;
    public Transform exitPoint;
    [Space]
    public float transitionSpeed = 1f;
    public GameObject BoardCamera;
    public GameObject playerCamera;
    private VehicleController vehicleController;
    public Transform skateBoard;
    public SphereCollider sphereCollider;
    public CollisionDetector colDetect;
    public bool isColliding;

    private void Start()
    {
        vehicleController = GetComponent<VehicleController>();
        vehicleController.enabled = false;        
    }   


    void Update()
    {

        if (vehicleActive && isInTransition)
        {
            Exit();
        }
                
        if (!vehicleActive && isInTransition)
        {
            Enter();
        }

        Vector3 playerFromPoint = player.transform.position;

       /* if (Input.GetKeyDown(KeyCode.E))
        {
            isInTransition = true;
        }
        */

        /*if (isInTransition == true)
        {
            Debug.Log("isInTransition = true");
        }
        */
    }

    public void Enter()
    {
        
        
        //Disable components
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<PlayerMovement>().enabled = false;




        //Move obj to designated seat
        //player.position = Vector3.Lerp(player.position, seatPoint.position + sittingoffset, transitionSpeed);                       
        player.transform.position = seatPoint.transform.position;
        //player.rotation = Quaternion.Slerp(player.rotation, seatPoint.rotation, transitionSpeed);
        player.transform.rotation = seatPoint.transform.rotation;
        player.transform.SetParent(seatPoint);
        

        /*Move obj to designated seat(alt)
        player.transform.position = seatPoint.transform.position;
        player.transform.SetParent(skateBoard.transform);
        */
        /* Player animation to sitting (will implement at a later date)
         
        player.GetComponentInChildren<Animator>().SetBool("Sitting", true);
        
         */
        //Activate the vehicle controller script when on board
        vehicleController.enabled = true;

        //Set board camera to active
        BoardCamera.SetActive(true);
        //Set player camera to inactive
        playerCamera.SetActive(false);

        /*Reset - check alternative

        if (isColliding == true)
        {
            isInTransition = false;
            vehicleActive = true;
        }
        */

        //Reset - check alternative 2
        if (Vector3.Distance(player.transform.position, seatPoint.position) < 10)
        {
            isInTransition = false;
            vehicleActive = true;
        }

        /* Reset - check
        
        if (player.position == seatPoint.position + sittingoffset)
        {          
            isInTransition = false;
            vehicleActive = true;
        }
        */

        if (vehicleActive == true)
        {
            Debug.Log("vehicleActive = true");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
        Debug.Log("Hit detected");
    }



    public void Exit()
    {
        //Move obj to designated exit point
        player.transform.position = exitPoint.position;
        player.transform.SetParent(null);

        /*Move obj to designated exit point(alt)
        player.transform.position = exitPoint.transform.position;
        */
        
        //Set obj animation to idle (will implement later)
        player.GetComponentInChildren<Animator>().SetBool("isSkating", false);


        //Deactivate the vehicle controller script when not on board
        vehicleController.enabled = false;

        //Set board camera to inactive
        BoardCamera.SetActive(false);
        //Set player camera to active
        playerCamera.SetActive(true);

        //Reset - check
        if (vehicleController.enabled == false) 
        {
            isInTransition = false; 
            vehicleActive = false;
        }

        //Enable components
        player.GetComponent<CapsuleCollider>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
