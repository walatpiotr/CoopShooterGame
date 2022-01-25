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
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    obstacleToGrab.transform.position = Vector2.MoveTowards(obstacleToGrab.transform.position, mousePosition, 2f * Time.deltaTime);
        obstacleToGrab.transform.rotation = transform.rotation;
        }
    }
}
