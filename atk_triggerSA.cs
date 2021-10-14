using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk_triggerSA : MonoBehaviour
{
    public int dmg = 5;
    public int dmg_SA = 10;

    void OnTriggerEnter2D(Collider2D col)// this is a sunction that checks any 2d colliders that it come in contact with 
    {
        if (col.isTrigger != true && col.CompareTag("player2"))
        //if the box collider this script is attached to is triggered through punch or kick and the contact object has a tag of player2 
        {
            col.SendMessageUpwards("Damage", dmg_SA);
            healthBar2.health2 -= 10f;
            // Damage function will be called and subtract 5 from the other player health in the player2 script which is called Dmg_taken 
        }

        /*    if (col.isTrigger != true && col.CompareTag("def_2") && col.CompareTag("player2"))
            {
                col.SendMessageUpwards("Damage", dmg_cancel);
                dmg = 0;
                Debug.Log(dmg);
            }

        }
        */


    }

}
