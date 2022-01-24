using System.Collections.Generic;
using UnityEngine;

public class GravityPossibilityScript : MonoBehaviour
{
    public Transform grabSprite;

    public List<SpriteRenderer> spritesEnabled;

    void Update()
    {
        CheckIfPlayerNearby();
    }

    private void CheckIfPlayerNearby()
    {
        var obstacles = GameObject.FindGameObjectsWithTag("obstacle");

        if(transform.GetComponent<GravityGun>().obstacleToGrab == null)
        {
            // grabSprite.enabled = false;

            foreach (var obstacle in obstacles)
            {
                if (Vector2.Distance(obstacle.transform.position, transform.position) < 3f)
                {
                    grabSprite = obstacle.transform.Find("GravityGunEnablePopUp");
                    grabSprite.GetComponent<SpriteRenderer>().enabled = true;
                    spritesEnabled.Add(grabSprite.GetComponent<SpriteRenderer>());
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    { transform.GetComponent<GravityGun>().obstacleToGrab = obstacle; }
                }
            }
        }

        if(spritesEnabled.Count > 0)
        {
            foreach (var sprite in spritesEnabled)
            {
                if (Vector2.Distance(sprite.transform.position, transform.position) >= 3f)
                {
                    sprite.enabled = false;
                    spritesEnabled.Remove(sprite);
                }
            }
        }
    }
}
