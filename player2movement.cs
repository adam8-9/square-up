using UnityEngine;

public class player2movement : MonoBehaviour{
    public Animator animator;
    public CharacterController2D control;
    public float runSpeed2 = 40f;
    public float horizontalMove2 = 0f;
    bool up2 = false;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove2 = Input.GetAxisRaw("Horizontal2") * runSpeed2;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove2));

        if (Input.GetButton("UP2"))
        {
           up2 = true;
           animator.SetBool("jump", true);


        }
        else if (Input.GetKeyDown("i") || (Input.GetKeyDown("o") || (Input.GetKeyDown("p"))))
        {
            up2 = false;
            animator.SetBool("jump", false);
        }

    }

    public void Landing()
    {
        animator.SetBool("jump", false);

    }
    void FixedUpdate()
    {
        // moves character
        control.Move(horizontalMove2 * Time.fixedDeltaTime, false, up2);
        up2 = false;

    }

    
















}
