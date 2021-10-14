using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_atk : MonoBehaviour
{
    bool punch_b = false;
    bool kick_b = false;
    bool SA = false;


    private float atkTimer = 0;
    private float atkCd = 0.3f;

    public Collider2D player2_trigger;
    public Collider2D player2_triggerSA;

    public Transform SA_firepoint;
    public GameObject SAPrefab;

    public Animator animator;

    public int SAtotal = 0;
    public float SAtimer = 0;
    public float SAcd = 0;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        player2_trigger.enabled = false;

    }

    void Update()
    {

        if (Input.GetKeyDown(",") && !punch_b)
        {
            punch_b = true;
            atkTimer = atkCd;

            player2_trigger.enabled = true;

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
                player2_trigger.enabled = false;
            }
        }

        animator.SetBool("punch_b", punch_b);

        if (Input.GetKeyDown(".") && !kick_b)
        {
            kick_b = true;
            atkTimer = atkCd;

            player2_trigger.enabled = true;

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
                player2_trigger.enabled = false;
            }
            
        }
        animator.SetBool("kick_b", kick_b);

        if (Input.GetKeyDown("m") && !SA)
        {
            SA = true;
            Debug.Log("sa");
            atkTimer = atkCd;
            // this checks if the player enters the button punch button which is i, if so then punch becomes true 
            StartCoroutine(SAtrigger());

            Shoot();
            // the trigger then also becomes true 

            SAtotal += 1;
        }

        IEnumerator SAtrigger()
        {
            yield return new WaitForSeconds(0.45f);
            player2_triggerSA.enabled = true;
        }

        if (SAtotal == 1)
        {
            SAtimer = SAcd;
            SAtotal = 0;
        }

        if (SAtimer > 0)
        {
            SAtimer -= Time.deltaTime;
            SA = false;
            player2_triggerSA.enabled = false;
            SAtotal = 0;
        }

        /*  else
          {
              SA = true;
              player1_triggerSA.enabled = true;
          }*/

        if (SA)
        {
            if (atkTimer > 0)
            {
                atkTimer -= Time.deltaTime;// if the atk timer is bigger then 0 then this line will decrease the time by delta time which works as a real timer 
            }
            else
            {
                SA = false;
                player2_triggerSA.enabled = false;
                // if player is not usinf the punch key button then punching becomes false and the trigger will also be false 
            }
        }

        animator.SetBool("brolySA", SA);


    }


    void Shoot()
    {
        Instantiate(SAPrefab, SA_firepoint.position, SA_firepoint.rotation);
    }
}
