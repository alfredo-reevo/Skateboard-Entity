using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_vehicle : MonoBehaviour
{
    public Camera cam;
    public vehicle vehicle;

    private void Start()
    {
        vehicle = GameObject.Find("skateboard").GetComponent<vehicle>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            vehicle.isInTransition = true;
            DoRay();
        }
    }

    void DoRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Board")
            {
                hit.collider.GetComponent<vehicle>().Enter();
            }
            else if (hit.collider.tag == "Default")
            {            
                hit.collider.GetComponent<vehicle>().Exit();
            }
        }
    }
}
