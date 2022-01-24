using UnityEngine;

public class GravityPossibilityScript : MonoBehaviour
{
    public Transform grabSprite;
    
    void Update()
    {
        CheckIfPlayerNearby();
    }

    private void CheckIfPlayerNearby()
    {
        var obstacles = GameObject.FindGameObjectsWithTag("obstacle");

        // grabSprite.enabled = false;

        foreach (var obstacle in obstacles)
        {
            if (Vector2.Distance(obstacle.transform.position, transform.position) < 3f)
            {
                grabSprite = obstacle.transform.Find("GravityGunEnablePopUp");
                grabSprite.GetComponent<SpriteRenderer>().enabled = true;
                transform.GetComponent<GravityGun>().obstacleToGrab = obstacle;
            }
        }
    }
}
