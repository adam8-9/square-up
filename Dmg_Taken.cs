using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg_Taken : MonoBehaviour
{
    public float curHealth = 0;
    public float maxHealth = 100;
    public Animator animator;
    bool dmg_anim = false;
  




    void start()
    {
        curHealth = maxHealth;
        
    }

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        

    }

    void Update()
    {

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }







    }
    public void Damage(int damage)
    {
        curHealth -= damage;
      

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
