using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnedMegaFB : MonoBehaviour
{
    //public EnemyMoveScript EMScript;
    public float speed = 20f;

    private float nextFire;
    private float fireRate;

 

    private float maxDistance = 0f;
    //movement direction

    private Vector2 movement;

    GameObject character;
    public Rigidbody2D rigidbodyComponent; //connect to Unity's RB

    Transform tf;
    void Start()
    {
        tf = GetComponent<Transform>();
        //Vector3 position = new Vector3(tf.position.x, Random.Range(MinimumY, MaximumY), 0);
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
        //if (col.gameObject.tag == "Enemy")
        //{

           




        //    //foreach (Transform child in transform)
        //    //{
        //    //    Destroy(child.gameObject);
        //    //}
        //    //Destroy(gameObject);

        //    //if ()
        //    //{
        //    //    Destroy(gameObject);
        //    //}


        //}
    }
}