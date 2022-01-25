using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Camera cam;

    public bool grabObstacle = false;

    public RaycastHit2D hitted;

    public GameObject obstacleToGrab;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            grabObstacle = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            grabObstacle = false;
            //obstacleToGrab.transform.parent = null;
            obstacleToGrab = null;
        }
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition = cam.ViewportToWorldPoint(Input.mousePosition);
        //Debug.Log(transform.position + " + " + mousePosition);

        if (grabObstacle)
        {
            if (obstacleToGrab)
            {
                obstacleToGrab.transform.position = mousePosition;
            }
        }
    }
}
