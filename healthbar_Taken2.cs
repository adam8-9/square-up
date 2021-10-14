using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar_Taken2 : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D col)// this function works when the trigger of another gameobject enters the ojbect this script is attached to 
   {

    if ( col.CompareTag("player1_trigger"))
      {
          healthBar2.health2 -= 5f;
          // if the tag of another gameobject which is player1 trigger then the healthbar image will decrease by 5  
      }



  }
     /*     private void OnTriggerEnter2D(CircleCollider2D col2)
          {

              if (col2.isTrigger != true && col2.CompareTag("player1_trigger"))
              {
                  healthBar2.health2 -= 5f;
              }


          }

          */
          // this was an attempt to make the healthbar from decreasing before i put in the simple code in line 13, it did work previously but stopped after some time


    
}
