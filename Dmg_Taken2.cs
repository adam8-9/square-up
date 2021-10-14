using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg_Taken2 : MonoBehaviour
{
    public float curHealth2 = 0;
    public float maxHealth2 = 100;

    void start()
    {
        curHealth2 = maxHealth2;     
    }

    void Update()
    {

        if (curHealth2 <= 0)
        {
            Destroy(gameObject);
        }

    }
    public void Damage(int damage)
    {
        curHealth2 -= damage;
      
    }

   /* private void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.tag == "player2")
      {
           animator.SetTrigger("Hit");
       }
       else
        {
            animator.SetTrigger("idle2");

        }
   }*/
    

}
