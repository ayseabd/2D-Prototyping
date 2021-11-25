using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMe : MonoBehaviour
{
    public float aliveTime;

    // Start is called before the first frame update

    // Awake is occurs when the object first comes to life
    void Awake()
    {
        //(what we want to destroy, how long the object allowed to be alive)
        Destroy(gameObject, aliveTime); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
