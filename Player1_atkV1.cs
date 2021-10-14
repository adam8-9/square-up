using UnityEngine;
using System.Collections;

public class Player1_atkV1 : MonoBehaviour
{

    bool punch = false;
    bool kick = false;
    // the above variables set punch and kick to false 
    private float atkTimer = 0;
    private float atkCd = 0.1f;
    // the float variables are used for the delays between attacks
    public Collider2D player1_triggerV1; // this references the collider that is the child of the gameObject which is the character 
    public Animator animator;
    public int punchTotal = 0;
    public float punchTimer = 0;
    public float punchCd = 2;

    public int kickTotal = 0;
    public float kickTimer = 0;
    public float kickCd = 0;
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        player1_triggerV1.enabled = false;// this sets the trigger in the begging of the game to false 

    }

    void Update()
    {

        if (Input.GetKeyDown(",") && !punch)
        {
            punch = true;
            atkTimer = atkCd;
            // this checks if the player enters the button punch button which is i, if so then punch becomes true 

            player1_triggerV1.enabled = true;
            // the trigger then also becomes true 

            punchTotal += 1;

        }

        if (punchTotal == 4)
        {
            punchTimer = punchCd;
            punchTotal = 0;
        }

        if (punchTimer > 0)
        {
            punchTimer -= Time.deltaTime;
            punch = false;
            player1_triggerV1.enabled = false;
            punchTotal = 0;
        }
        /*  else
          {
              punch = true;
              player1_trigger.enabled = true;
          }*/

        if (punch)
        {
            if (atkTimer > 0)
            {
                atkTimer -= Time.deltaTime;// if the atk timer is bigger then 0 then this line will decrease the time by delta time which works as a real timer 
            }
            else
            {
                punch = false;
                player1_triggerV1.enabled = false;
                // if player is not usinf the punch key button then punching becomes false and the trigger will also be false 
            }
        }

        animator.SetBool("punch", punch);
        // this will set the punch animation in the animator of player 1 to true or false depending on the two if statements above 

        if (Input.GetKeyDown(".") && !kick)
        {
            kick = true;
            atkTimer = atkCd;
            // this checks if the player enters the button punch button which is i, if so then punch becomes true 

            player1_triggerV1.enabled = true;
            // the trigger then also becomes true 

            kickTotal += 1;
        }

        if (kickTotal == 4)
        {
            kickTimer = kickCd;
            kickTotal = 0;
        }

        if (kickTimer > 0)
        {
            kickTimer -= Time.deltaTime;
            kick = false;
            player1_triggerV1.enabled = false;
            kickTotal = 0;
        }

        if (kick)
        {
            if (atkTimer > 0)
            {
                atkTimer -= Time.deltaTime;// if the atk timer is bigger then 0 then this line will decrease the time by delta time which works as a real timer 
            }
            else
            {
                kick = false;
                player1_triggerV1.enabled = false;
                // if player is not usinf the punch key button then punching becomes false and the trigger will also be false 
            }
        }

        animator.SetBool("kick", kick);
        // this will set the punch animation in the animator of player 1 to true or false depending on the two if statements above 



    }

}
