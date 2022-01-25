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

            // TODO refactor bcz it goes on z axis (?)
        Vector2 mousePosition = (Vector2)cam.ScreenToViewportPoint(Input.mousePosition);
        mousePosition = obstacleToGrab.transform.position + (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f));
        obstacleToGrab.transform.position = Vector2.MoveTowards(obstacleToGrab.transform.position, mousePosition, 2f * Time.deltaTime);            
        obstacleToGrab.transform.rotation = transform.rotation;

        }
    }
}
