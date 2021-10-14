using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goku_dmg : MonoBehaviour
{
    public Animator onHit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player2_trigger"))
        {
            onHit.SetBool("taken_g", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player2_trigger"))
        {
            onHit.SetBool("taken_g", false);
        }
    }
}
