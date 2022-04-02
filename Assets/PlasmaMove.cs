﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlasmaMove : MonoBehaviour
{
    //public EnemyMoveScript EMScript;
    public float speed = 50f;

    private float nextFire;
    private float fireRate;

    private float maxDistance = 0f;
    //movement direction

    private Vector2 movement;

    GameObject character;
    public Rigidbody2D rigidbodyComponent; //connect to Unity's RB

    bool spawnPlasma = true;
    public GameObject PlasmaExplosion;

    Transform explosionSpawn;
    void Start()
    {

        explosionSpawn = GetComponent<Transform>();
    }

    // Use this for initialization
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed);
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        //How far the bullet can travel before it gets destroyed
        maxDistance += Time.deltaTime;
        if (maxDistance >= 4) Destroy(this.gameObject);


                //why does it break if its not 4?


        //------------------------------------------------------

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
           
                Instantiate(PlasmaExplosion, explosionSpawn.position, explosionSpawn.rotation);
            
                Destroy(gameObject);
       
            
            //if ()
            //{
            //    Destroy(gameObject);
            //}


        }
    }
}