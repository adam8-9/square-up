using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk_trigger2 : MonoBehaviour
{
    public int dmg2 = 5;
    Animator animator;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("player1"))
        {
            col.SendMessageUpwards("Damage", dmg2);
            healthbar.health -= 5f;
        }
    }

    

}