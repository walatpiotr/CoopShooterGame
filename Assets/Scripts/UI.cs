using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public float health;
    public float ammo;
    public float mags;
    public TMP_Text textbox;
    GameObject player;
    public string currentWeapon;
    public Image img;
    void Start()
    {

        textbox = GetComponentInChildren<TMP_Text>();
        player=GameObject.FindWithTag("Player");
        img=GetComponentInChildren<Image>();
        
    }

    void Update()
    {
        currentWeapon=player.GetComponent<Shooting>().currentWeapon;

        health=player.GetComponent<HealthBar>().curHealth;
        ammo=player.GetComponent<Shooting>().currentMagazine;
        mags=player.GetComponent<Shooting>().magazines[currentWeapon].Item2;

        textbox.text = "Health:"+health+"  Ammo:"+ammo+"  Magazines:"+mags;
        img.sprite=Resources.Load<Sprite>("Guns/"+currentWeapon);
    }
}
