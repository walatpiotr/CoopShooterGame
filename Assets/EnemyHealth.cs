using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

  public float maxHealth = 100;
  public float curHealth = 100;
  private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg){
        curHealth -= dmg;
        if (curHealth<=0){
            Destroy(this.gameObject);
        }
        spriteRenderer=this.transform.Find("HealthBar").GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size = new Vector2((float)curHealth/(float)maxHealth,(float)1);
    }
  
}
