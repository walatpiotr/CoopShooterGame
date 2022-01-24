using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public float health;
    public float ammo;
    public TMP_Text textbox;
    void Start()
    {

        textbox = GetComponentInChildren<TMP_Text>();
        
        
    }

    void Update()
    {
        health=GameObject.FindWithTag("Player").GetComponent<HealthBar>().curHealth;
        ammo=GameObject.FindWithTag("Player").GetComponent<Shooting>().currentMagazine;

        textbox.text = "Health: "+health+"     Ammo: "+ammo;
    }
}
