using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_2v1 : MonoBehaviour
{
    private Rigidbody2D rb2;
    public float dashSpeed2;
    private float dashTime2;
    public float startTime2;
    private int direction_2;
    public int rightTotal2 = 0;
    public float rightTime2 = 0;
    public int leftTotal2 = 0;
    public float leftTime2 = 0;
    public Animator anim2;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        dashTime2 = startTime2;
        anim2 = gameObject.GetComponent<Animator>();
    }
    void Update()
    {

        if (direction_2 == 0)
        {
            if (Input.GetKeyDown("d"))
            {
                rightTotal2 += 1;
                // if the player enters the right key which is D then the count for how many times they pressed that will increase by 1 
            }

            if ((rightTotal2 == 1) && (rightTime2 < 0.2))
                rightTime2 += Time.deltaTime;
            //if the count for how many times they pressed they left key is 1 and the time for long it has been since they pressed it is less than 0.2 seconds 
            // then the timer activates 

            if ((rightTotal2 == 1) && (rightTime2 >= 0.2))
            {
                rightTime2 = 0;
                rightTotal2 = 0;
                // if the count for left key pressed is still 1 and has been more than or equal to 0.2 seconds then count goes back to 0 so will the timer 

                anim2.SetBool("broly_dash", false);
                // this sets the double dash to false if the the above if statement is true 

            }

            if ((rightTotal2 == 2) && (rightTime2 < 0.2))
            {
                direction_2 = 2;
                rightTotal2 = 0;
                anim2.SetBool("broly_dash", true);
                //if left key is pressed twice and the time that has elapsed after the first count is still less than 0.2 seconds then the double dash animtion plays for player1

            }

            else if  (Input.GetKeyDown("a"))
            {
                leftTotal2 += 1;
                // if the player enters the right key which is D then the count for how many times they pressed that will increase by 1 
            }

            if ((leftTotal2 == 1) && (leftTime2 < 0.2))
                leftTime2 += Time.deltaTime;
            //if the count for how many times they pressed they left key is 1 and the time for long it has been since they pressed it is less than 0.2 seconds 
            // then the timer activates 

            if ((leftTotal2 == 1) && (leftTime2 >= 0.2))
            {
                leftTime2 = 0;
                leftTotal2 = 0;
                // if the count for left key pressed is still 1 and has been more than or equal to 0.2 seconds then count goes back to 0 so will the timer 

                anim2.SetBool("broly_dash", false);
                // this sets the double dash to false if the the above if statement is true 

            }

            if ((leftTotal2 == 2) && (leftTime2 < 0.2))
            {
                direction_2 = 1;
                leftTotal2 = 0;
                anim2.SetBool("broly_dash", true);
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
            if (dashTime2 <= 0)
            {
                direction_2 = 0;
                dashTime2 = startTime2;
                rb2.velocity = Vector2.zero;
            }
            else
            {
                dashTime2 -= Time.deltaTime;
                if (direction_2 == 1)
                {
                    rb2.velocity = Vector2.left * dashSpeed2;
                }
                else if (direction_2 == 2)
                {
                    rb2.velocity = Vector2.right * dashSpeed2;
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
