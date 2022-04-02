using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravitronMove : MonoBehaviour
{
    //public EnemyMoveScript EMScript;
    public float speed = 50f;


    PointEffector2D PtEffect;

    float timer = 0f;
    //private float maxDistance = 0f;
    //movement direction

    private Vector2 movement;

    GameObject character;
    public Rigidbody2D rigidbodyComponent; //connect to Unity's RB



    SpriteRenderer sr;

    public Sprite pull;

    CircleCollider2D cc;

    public GameObject GravitronBurn;
    int noSpawnBurn = 0;


    Transform burnSpawn;
    void Start()
    {
        PtEffect = GetComponent<PointEffector2D>();
        //sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
        burnSpawn = GetComponent<Transform>();
        
    }
    //void Start()
    //{

    //    render = GetComponent<SpriteRenderer>();
    //}

    // Use this for initialization
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector2.up * speed);
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        //How far the bullet can travel before it gets destroyed



        if (timer >= 2) {


            GetComponent<SpriteRenderer>().color = new Color(1, 0.141598f, 0f);
            PtEffect.forceMagnitude = -24000;

        }
        //------------------------------------------------------
        if (timer >= 4) {

            PtEffect.forceMagnitude = 45000;

            if (noSpawnBurn == 0)
            {
                Instantiate(GravitronBurn, burnSpawn.position, burnSpawn.rotation);
                noSpawnBurn = +1;
            }
        }
        
           
        if(timer >= 4.4)
        {
            GravitronBurn.GetComponent<DestroyGravBurn>().destroy = true;
        }
            
           
        
        if (timer >= 4.5)
        {
            noSpawnBurn = 0;
            
            Destroy(gameObject);
        }

    }

}

   
