using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goku_def : MonoBehaviour
{

    public Animator anim;
    bool def_g = false;
    public Collider2D def2_trigger;
    // both of the above triggers will be used to reference player2's colliders that will be activated when the defend button is activated  
    private float defTimer = 0;
    private float defCd = 3;
    // the 2 float variables above will be used to set the countdown of how long the def barrier lasts for 

    void Awake()
    {
        def2_trigger.enabled = false;
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown("p") && !def_g)
        {
            def_g = true;
            def2_trigger.enabled = true;
            // if the user has entered the guard key then defend will be true and so will the trigger 

            defTimer = defCd;// this will make the barrier last for 3 seconds 
            transform.gameObject.tag = ("def");
            // this line of code will change the player2's tag from player2 to def_2 this way when player1 attacks it will detect the tag and cancel the damage being dealt
            Debug.Log(tag);
            print(tag);
            // the 2 lines above will print to the console if the tag has changed 
        }

        else if (Input.GetKeyDown("i") || (Input.GetKeyDown("o")))
        {
         def_g = false;
         anim.SetBool("def_g", false);
        }

        if (def_g)
        {
            if (defTimer > 0)
            {
                defTimer -= Time.deltaTime;
                // this will act as a timer for the guard barrier to go down 
            }
            else
            {
                def_g = false;
                def2_trigger.enabled = false;
                transform.gameObject.tag = ("player1");
                // if player 2 isnt defending anymore then teh tag will go back to player2 and player1 can return to doing damage 
            }

            anim.SetBool("def_g", def_g);
            // this line will play the aniimtion of the guard barrier depending on whether player 2 has entered the guard button 

        }






    }






}
