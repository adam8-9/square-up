using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmg_Anim : MonoBehaviour
{
    public Animator onHit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player1_trigger"))
        {
            onHit.SetBool("taken_b", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player1_trigger"))
        {
            onHit.SetBool("taken_b", false);
        }
    }
}
