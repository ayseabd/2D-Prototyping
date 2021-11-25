using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketHit : MonoBehaviour
{
    public float weaponDamage;

    projectileController myPC;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<projectileController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable")) // we can also use the number of shootable layer
        {
            //first we want to rocket to stop. Go to projectile controller script and create removeForce function
            //now call new function
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation); // instantiate (what, where, rotation)
            //destroy the missile
            Destroy(gameObject); //by doing it this way we destroy the game object rather than the parent game object,
                                 //so we can see the smoke after destroying the missile. (Projectile -> missile + missileSmoke)

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable")) // we can also use the number of shootable layer
        {
            //first we want to rocket to stop. Go to projectile controller script and create removeForce function
            //now call new function
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation); // instantiate (what, where, rotation)
            //destroy the missile
            Destroy(gameObject); //by doing it this way we destroy the game object rather than the parent game object,
                                 //so we can see the smoke after destroying the missile. (Projectile -> missile + missileSmoke)

        }
    }

}
