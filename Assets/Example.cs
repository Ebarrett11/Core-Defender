using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public float floatHeight;     // Desired floating height.
    public float liftForce;       // Force to apply when lifting the rigidbody.
    public float damping;         // Force reduction proportional to speed (reduces bouncing).

    Rigidbody2D rb2D;

    public float yOffset;
    public Vector3 offset;


    void Start()
    {
        offset = new Vector3(0, yOffset, 0);
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, -transform.right);

        // If it hits something...
        if (hit.collider != null)
        {
            Debug.Log(hit.distance);
            if (hit.distance < 1)
            {
                Debug.Log("attack");
            }
          
            
            
        }
    }
}