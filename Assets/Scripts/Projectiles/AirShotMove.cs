using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AirShotMove : MonoBehaviour
{
    //public EnemyMoveScript EMScript;
    public float speed = 20;
    private float nextFire;
    private float fireRate;

    private float maxDistance = 0f;
    //movement direction
    SpriteRenderer shotImage;

    private Vector2 movement;

    GameObject character;
    public Rigidbody2D rigidbodyComponent; //connect to Unity's RB

    void Start()
    {

    }

    // Use this for initialization
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed);
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        //How far the bullet can travel before it gets destroyed
        maxDistance += Time.deltaTime;
        if (maxDistance >= 1) Destroy(this.gameObject);
        //------------------------------------------------------

        
    }

    
}