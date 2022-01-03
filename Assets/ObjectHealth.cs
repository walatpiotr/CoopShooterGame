using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
  public int maxHealth = 200;
  public int curHealth = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg){
        curHealth -= dmg;
        if (curHealth<=0){
            Destroy(this.gameObject);
        }

    }
}
