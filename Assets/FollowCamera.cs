using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    //determines how close character
    //can get to edge of screen before camera move
    public float xMargin = 1.5f;
    public float yMargin = 1.5f;

    //impacts how smoothly camera pans
    public float xSmooth = 1.5f;
    public float ySmooth = 1.5f;

    //identify how far the camera can move 
    //left or right, up an down
    public Vector2 maxXandY;
    public Vector2 minXandY;

    //will determine which gameObject
    //to follow
    public Transform player;

    // Use this for initialization
    void Start()
    {
      
    }

    bool CheckXMargin()
    {
        //return true if distance requested X is > than margi.n space
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        //return true if distance requested Y is > than the margin space
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())
        {                        //point B             point A                      how quickly move camera
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        }

        if (CheckYMargin())
        {                       //point B             point A                      how quickly move camera
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);
        }

        //clamping, setting the min and max values for where the camera is allowed to go
        targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);
        targetY = Mathf.Clamp(targetY, minXandY.y, maxXandY.y);

        //apply the transformation (move camera)
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
