using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class playermovement : MonoBehaviour {
    public Animator animator; // this references the animator which controls all the animations that the character does in the game
    public CharacterController2D control;// this is the script i will be referncing to make the charcter move smoothly 
  
    public float runSpeed = 40f;  
    public float horizontalMove = 0f;
    public float horizontalMove1 = 0f;
    // the variables above will control movement speed
    public bool up = false;

    void Start()
    {
    
        

    }

    public void Update()
    {
        {
            // horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            // horizontalMove1 = Input.GetAxisRaw("Horizontal1") * runSpeed;

           horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
          
            //horizontalMove1 = Input.GetAxisRaw("Horizontal1") * runSpeed;

            //GetAxisRaw determines if the player is going left or right by the value -1 moving left and 1 when moving right then runSpeed multplies the value by 40 to give the character speed 
            animator.SetFloat("speed", Mathf.Abs(horizontalMove));
           // animator.SetFloat("speed1", Mathf.Abs(horizontalMove1));
            // this is used to get the input from the keyboard for horizantal movement and runSpeed will control how fast they can move 
            // the animator refernced will play the animation for moving left anf right
            //Mathf.Abs is used to keep the speed value always poistive even when it is going left which is -1
        }

        if (Input.GetButton("UP"))
        {
            up = true;
           //up1 = true;
            animator.SetBool("jump", true);
            // this is to figure out if the player is jumping or not, if os the animtion for jump will be played 
        }
        else if (Input.GetKeyDown("i") || (Input.GetKeyDown("o") || (Input.GetKeyDown("p"))))
        {
            up = false;
           // up1 = false;
            animator.SetBool("jump", false);
        }
    }

    public void Landing(){
        animator.SetBool("jump", false);
        // if they are not jumping the animation wont play 
    }

    void FixedUpdate(){
        // moves character
        control.Move (horizontalMove * Time.fixedDeltaTime, false, up);
    
        
        up = false;
       
}
}
