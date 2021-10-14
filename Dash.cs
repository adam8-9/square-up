using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startTime;
    private int direction;
    public int rightTotal = 0;
    public float rightTime = 0;
    public int leftTotal = 0;
    public float leftTime = 0;
    public Animator anim;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startTime;
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {

        if( direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rightTotal += 1;
                // if the player enters the right key which is D then the count for how many times they pressed that will increase by 1 
            }

             if((rightTotal ==1) && (rightTime < 0.2))
                rightTime += Time.deltaTime;
             //if the count for how many times they pressed they left key is 1 and the time for long it has been since they pressed it is less than 0.2 seconds 
             // then the timer activates 
            
                if((rightTotal == 1) && (rightTime >= 0.2))
                {
                    rightTime = 0;
                    rightTotal = 0;
                  // if the count for left key pressed is still 1 and has been more than or equal to 0.2 seconds then count goes back to 0 so will the timer 
                
                    anim.SetBool("goku_dash", false);
                // this sets the double dash to false if the the above if statement is true 

                }

            if ((rightTotal == 2) && (rightTime < 0.2))
            {
                direction = 2;
                rightTotal = 0;
                anim.SetBool("goku_dash", true);
                //if left key is pressed twice and the time that has elapsed after the first count is still less than 0.2 seconds then the double dash animtion plays for player1

            }
            
            else if (Input.GetKeyDown(KeyCode.A))
            {
                leftTotal += 1;
                // if the player enters the right key which is D then the count for how many times they pressed that will increase by 1 
            }

            if ((leftTotal == 1) && (leftTime < 0.2))
                leftTime += Time.deltaTime;
            //if the count for how many times they pressed they left key is 1 and the time for long it has been since they pressed it is less than 0.2 seconds 
            // then the timer activates 

            if ((leftTotal == 1) && (leftTime >= 0.2))
            {
                leftTime = 0;
                leftTotal = 0;
                // if the count for left key pressed is still 1 and has been more than or equal to 0.2 seconds then count goes back to 0 so will the timer 

                anim.SetBool("goku_dash", false);
                // this sets the double dash to false if the the above if statement is true 

            }

            if ((leftTotal == 2) && (leftTime < 0.2))
            {
                direction = 1;
                leftTotal = 0;
                anim.SetBool("goku_dash",true);
                //if left key is pressed twice and the time that has elapsed after the first count is still less than 0.2 seconds then the double dash animtion plays for player1
            }

            /*   else if (Input.GetKeyDown(KeyCode.W))
                {
                    direction = 3;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    direction = 4;
                }
                */

        // the code below will handle how fast the speed is of the double dash 

        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if(direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }else if( direction ==2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                
               /* else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }*/
            }
        }

    }
}
