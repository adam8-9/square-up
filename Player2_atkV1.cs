using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_atkV1 : MonoBehaviour
{
    bool punch_b = false;
    bool kick_b = false;


    private float atkTimer = 0;
    private float atkCd = 0.3f;

    public Collider2D player2_triggerV1;

    public Animator animator;



    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        player2_triggerV1.enabled = false;

    }

    void Update()
    {

        if (Input.GetKeyDown("i") && !punch_b)
        {
            punch_b = true;
            atkTimer = atkCd;

            player2_triggerV1.enabled = true;

        }

        if (punch_b)
        {
            if (atkTimer > 0)
            {
                atkTimer -= Time.deltaTime;
            }
            else
            {
                punch_b = false;
                player2_triggerV1.enabled = false;
            }
        }

        animator.SetBool("punch_b", punch_b);

        if (Input.GetKeyDown("o") && !kick_b)
        {
            kick_b = true;
            atkTimer = atkCd;

            player2_triggerV1.enabled = true;

        }

        if (kick_b)
        {
            if (atkTimer > 0)
            {
                atkTimer -= Time.deltaTime;
            }
            else
            {
                kick_b = false;
                player2_triggerV1.enabled = false;
            }

        }
        animator.SetBool("kick_b", kick_b);




    }

}
