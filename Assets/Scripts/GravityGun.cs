using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Camera cam;

    public bool grabObstacle = false;
    public bool grabbingObstacle = false;

    public RaycastHit2D hitted;

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
            grabbingObstacle = false;
        }
        MoveObstacle();
        GrabbingMethod();
    }

    private void MoveObstacle()
    {
        if (grabObstacle)
        {
            ////////

            RaycastHit2D[] allHits;
            allHits = Physics2D.RaycastAll(transform.position, cam.ScreenToWorldPoint(Input.mousePosition), 10f);
            Debug.Log(allHits.Length);
            Debug.DrawLine(transform.position, cam.ScreenToWorldPoint(Input.mousePosition), Color.yellow);

            foreach (var hited in allHits)
            {
                Debug.DrawLine(hited.transform.position, cam.ScreenToWorldPoint(Input.mousePosition), Color.red);

                if (hited.transform.tag == "obstacle" /*&& (Vector2.Distance(hited.transform.position, cam.ScreenToWorldPoint(Input.mousePosition))<0.2f)*/)
                {
                    grabbingObstacle = true;
                    grabObstacle = false;
                    Debug.Log("tadam!");
                    hitted = hited;
                }
            }
        }
    }

    private void GrabbingMethod()
    {
        if (grabbingObstacle && Vector2.Distance(transform.position, hitted.transform.position)<10f)
        {
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            hitted.transform.position = mousePosition;
        }
    }
}
