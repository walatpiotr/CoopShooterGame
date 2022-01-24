using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public float maxHealth = 100;
    public float curHealth = 100;
    private SpriteRenderer spriteRenderer;

    private Transform healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = this.transform.Find("HealthBar");
    }

    // Update is called once per frame
    void Update()
    {
        // TODO fixe health bar - there is some error thrown here
        healthBar.eulerAngles = new Vector3(0, 0, 0);
        healthBar.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.7f, 0f);
    }

    public void TakeDamage(float dmg){
        curHealth -= dmg;
        if (curHealth<=0){
            Destroy(this.gameObject);
        }
        spriteRenderer=this.transform.Find("HealthBar").GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size = new Vector2(curHealth/maxHealth, 1f);

        
    }
  
}
