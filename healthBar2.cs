using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar2 : MonoBehaviour
{

    Image healthBar_2;
    public float maxHealth2 = 100f;
    public static float health2;
    void Start()
    {
        healthBar_2 = GetComponent<Image>();// this refernces the image for player2 health bar 
        health2 = maxHealth2;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar_2.fillAmount = health2 / maxHealth2;
    }

    
}
