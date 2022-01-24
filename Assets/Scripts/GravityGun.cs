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
        }
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        if (grabObstacle)
        {
            obstacleToGrab.transform.position = Vector3.MoveTowards(obstacleToGrab.transform.position, cam.ScreenToWorldPoint(Input.mousePosition), 5f*Time.deltaTime);
            obstacleToGrab.transform.rotation = transform.rotation;
        }
    }
}
