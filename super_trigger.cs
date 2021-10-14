using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class super_trigger : MonoBehaviour
{
    public Rigidbody2D rb;
    public int Take = 10;
    void Start()
    {
         
    }

     void OnTriggerEnter2D(Collider2D hit)
    {
        dmg_Taken player2 = hit.GetComponent<dmg_Taken>();
        if (player2 != null)
        {
            player2.Damage(Take);
        }
        Destroy(gameObject);

    }


}
