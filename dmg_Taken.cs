using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmg_Taken : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
   
    void start()
    {
        curHealth = maxHealth;// this sets the player2 helath to 100 
        
    }

    void Update()
    {
        
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
        // if the player health is below 0 then the player2 will be destroyed in the game
    }
    public void Damage(int damage)
    {
        curHealth -= damage;
        // this function will be refernced by the player1 trigger whenever player1 is attacking player2 hp will decrease the amount of damage it sends to this script 
       
    }


   

}
