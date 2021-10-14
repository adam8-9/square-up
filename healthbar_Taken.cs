using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar_Taken : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("player2_trigger"))
        {
            healthbar.health -= 5f;
        }
    
     
        

    }
}
