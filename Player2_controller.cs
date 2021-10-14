using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player2_controller : MonoBehaviour
{
    [SerializeField] private float m_JumpForce2 = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed2 = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing2 = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl2 = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround2;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck2;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck2;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider2;                // A collider that will be disabled when crouching


    const float k_GroundedRadius2 = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded2;            // Whether or not the player is grounded.
    const float k_CeilingRadius2 = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D2;
    private bool m_FacingRight2 = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity2 = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent2;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent2;
    private bool m_wasCrouching2 = false;

    private void Awake()
    {
        m_Rigidbody2D2 = GetComponent<Rigidbody2D>();

        if (OnLandEvent2 == null)
            OnLandEvent2 = new UnityEvent();

        if (OnCrouchEvent2 == null)
            OnCrouchEvent2 = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded2 = m_Grounded2;
        m_Grounded2 = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders2 = Physics2D.OverlapCircleAll(m_GroundCheck2.position, k_GroundedRadius2, m_WhatIsGround2);
        for (int i = 0; i < colliders2.Length; i++)
        {
            if (colliders2[i].gameObject != gameObject)
            {
                m_Grounded2 = true;
                if (!wasGrounded2)
                    OnLandEvent2.Invoke();
            }
        }
    }


    public void Move2(float move2, bool crouch2, bool jump2)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch2)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck2.position, k_CeilingRadius2, m_WhatIsGround2))
            {
                crouch2 = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded2 || m_AirControl2)
        {

            // If crouching
            if (crouch2)
            {
                if (!m_wasCrouching2)
                {
                    m_wasCrouching2 = true;
                    OnCrouchEvent2.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move2 *= m_CrouchSpeed2;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider2 != null)
                    m_CrouchDisableCollider2.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider2 != null)
                    m_CrouchDisableCollider2.enabled = true;

                if (m_wasCrouching2)
                {
                    m_wasCrouching2 = false;
                    OnCrouchEvent2.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity2 = new Vector2(move2 * 10f, m_Rigidbody2D2.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D2.velocity = Vector3.SmoothDamp(m_Rigidbody2D2.velocity, targetVelocity2, ref m_Velocity2, m_MovementSmoothing2);

            // If the input is moving the player right and the player is facing left...
            if (move2 < 0 && !m_FacingRight2)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move2 > 0 && m_FacingRight2)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (m_Grounded2 && jump2)
        {
            // Add a vertical force to the player.
            m_Grounded2 = false;
            m_Rigidbody2D2.AddForce(new Vector2(0f, m_JumpForce2));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight2 = !m_FacingRight2;

        // Multiply the player's x local scale by -1.
        Vector3 theScale2 = transform.localScale;
        theScale2.x *= -1;
        transform.localScale = theScale2;
    }
}

