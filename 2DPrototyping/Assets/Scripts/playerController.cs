using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //DO NOT FORGET FREEZE ROTATITON Z FOR CHARACTER IN INSPECTOR PANE 

    //movement variables 
    public float maxSpeed;

    //jumping variables
    bool grounded = false; //player will look like jumping from the ship
    float groundCheckRadius = 0.2f; //how big the circle we created
    //DO NOT FORGET FORGET FILL THEM ON THE INSPECTOR PANE - DECREASE GRAVITY TO -30 TO GET SHARPER MOVES
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB; // reference to attached rb on player
    Animator myAnim; // allows us to manipulate parameters on animator controller
    bool facingRight;

    //for shooting
    public Transform gunTip; //for location
    public GameObject bullet; //reference to the projectile
    float fireRate = 0.5f; //character can shoot one rocket every 0.5 second
    float nextFire = 0f;  //when last time that the player fire his weapon (0 -> fire his weapon immediately)

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis inputs takes values between -1,1. If input is greater then zero, that means button is pushed.

        if (grounded && Input.GetAxis("Jump") > 0) // we're gonna use space bar to jump and space defined for Jump
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded); //grounded is false
            myRB.AddForce(new Vector2(0, jumpHeight));  //add force make that rigidbody moving
        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireRocket();
        }
    }

    //FixedUpdate is called after a specific time. Physics engines (RB) works properly with FixedUpdate. 
    void FixedUpdate()
    {
        //check if we are grounded if no, the we're falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // overlap circle draws a little circle and checks a number of things
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal"); // a, d and arrow keys are already defined in unity

        //DO NOT FORGET UNCHECK HAS EXIT TIME IN ANIMATOR CONTROLLER FOR BOTH IDLE TO RUN AND RUN TO IDLE
        myAnim.SetFloat("speed", Mathf.Abs(move)); //because the speed parameter is float.

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y); // y-axis does not affected

        if (move > 0 && !facingRight) // if player press d button and player facing left then flip.
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
    }

    //reverse the facing
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale; //vector3 because scale has 3 parameters x,y,z
        theScale.x *= -1; //if the scale x is 2 player facing right, if the scale is -2 then the player facing left
        transform.localScale = theScale;
    }

    void fireRocket()
    {
        //check whether or not player can shoot
        //Time.time is the current time that defined in game
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            //check facing
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0))); //what, where, rotation
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f))); //what, where, rotation(opposite)
            }

        }
    }
}
