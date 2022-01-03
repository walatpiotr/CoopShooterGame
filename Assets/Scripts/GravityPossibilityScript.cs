using UnityEngine;

public class GravityPossibilityScript : MonoBehaviour
{
    public SpriteRenderer grabSprite;
    
    void Update()
    {
        CheckIfPlayerNearby();
    }

    private void CheckIfPlayerNearby()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");

        grabSprite.enabled = false;

        foreach (var player in players)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < 3f)
            {
                if(player.GetComponent<GravityGun>().grabObstacle == false)
                {
                    grabSprite.enabled = true;
                    player.GetComponent<GravityGun>().obstacleToGrab = this.gameObject;
                }
            }
        }
    }
}
