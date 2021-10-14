using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class SA_speed : MonoBehaviour
{
   // public AnimationCurve xCurve, yCurve;

    private float timeElapsed = 0;
    private bool started = false;

    private Vector2 startPos;

    public float speed = 20f;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   /* private void FixedUpdate()
    {
        if (!started)
        {
            started = true;
            timeElapsed = 0;
            startPos = transform.position;
        }
        else
        {
            timeElapsed += Time.deltaTime;

            rb.MovePosition(new Vector2(
                startPos.x + xCurve.Evaluate(timeElapsed), 
                startPos.y + yCurve.Evaluate(timeElapsed))
                );
        }
    }*/


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
