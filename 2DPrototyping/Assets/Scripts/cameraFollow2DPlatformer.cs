using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour
{

    public Transform target; //what camera is following
    public float smoothing; // how quickly camera starts the follow (dampening effect)

    Vector3 offset; //difference between character and camera itself
    float lowY; // lowest point that our camera go

    // Start is called before the first frame update
    void Start()
    {
        //calculate and figure it out what initial position is
        offset = transform.position - target.position; // position of camera - position of target

        lowY = transform.position.y; //current position of camera
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if (transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z); //we're not interested in x and z posiitons)
        }
    }
}
