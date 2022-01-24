using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public float val;
    public TMP_Text textbox;
    void Start()
    {
        val=GameObject.FindWithTag("Player").GetComponent<HealthBar>().curHealth;
        textbox = GetComponentInChildren<TMP_Text>();
        
        
    }

    void Update()
    {
        val=GameObject.FindWithTag("Player").GetComponent<HealthBar>().curHealth;
        textbox.text = "Health: "+val;
    }
}
