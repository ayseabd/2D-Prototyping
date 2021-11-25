using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public float rocketSpeed;

    Rigidbody2D myRB;
    
    // Start is called before the first frame update
    // Awake is occurs when the object first comes to life
    void Awake() 
    {
        myRB = GetComponent<Rigidbody2D>();
        //when player !facingRinght
        if (transform.localRotation.z > 0) // Quaternion value of z- axis in fireRocket function is 180f
        {
            //the rocket will be able to move on x-axis
            myRB.AddForce(new Vector2(-1, 0) * rocketSpeed, ForceMode2D.Impulse);
        }
        else
            myRB.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse); //when player is facingRight

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // add after rocketHit script (to stop object)
    //remove all forces on rigidbody immediately
    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
