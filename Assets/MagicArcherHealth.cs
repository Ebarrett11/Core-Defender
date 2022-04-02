using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicArcherHealth : MonoBehaviour
{
    //global variables
    //accesible by any method in this class/script
    int hp = 3;


    bool burn = false;
    bool gravitronBurn = false;
    bool runGrav = true;
    bool freeze = false;
    bool runFreeze = true;
    bool phantom = false;
    bool phantomFix = false;
    bool plasma = false;


    private int burnCount = 0;

    float fireTimer = 0f;
    float gravitronTimer = 0f;
    float freezeTimer = 0f;
    float plasmaTimer = 0f;

    float fireEffectTimer = 0f;

    public GameObject goldSpawn;
    Transform goldTransform;


    //mega section
    bool MegaFB;

    // Use this for initialization
    void Start()
    {
        //GameObject.FindWithTag("Spawner").GetComponent<Spawner>().amountAlive += 1;
        //Child = GameObject.Find("Attack");
        //transform.GetChild(Child).GetComponent<TheComponent>().theVariable = theValue;
        BoxCollider2D box = GetComponentInChildren<BoxCollider2D>();
        goldTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {


        //code for the burn effect (not the initial 3 damamge)-------
        if (burn)
        {

            transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.259434f, 0.259434f);
            if (hp <= 0)
            {
                Instantiate(goldSpawn, goldTransform.position, goldTransform.rotation);
                //GameObject.FindWithTag("Spawner").GetComponent<Spawner>().amountAlive -= 1;
                Destroy(gameObject);
            }
            fireTimer += Time.deltaTime;
            fireEffectTimer += Time.deltaTime;

            //0.3884946
            if (fireEffectTimer >= .5 && fireEffectTimer <= 1)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 0.4020208f, 0.2588235f);
            }

            else if (fireEffectTimer >= 1)
            {
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.259434f, 0.259434f);
                fireEffectTimer = 0f;
            }


            if (fireTimer > 1)
            {

                hp -= 1;
                fireTimer = 0;
                burnCount += 1;
            }
            if (burnCount >= 3)
            {
                burn = false;
                burnCount = 0;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        if (freeze)
        {
            freezeTimer += Time.deltaTime;

            if (runFreeze) //makes sure that it only runs once
            {
                transform.GetChild(1).gameObject.SetActive(true);
                GetComponent<SpriteRenderer>().color = new Color(0.4269758f, 0.6026953f, 0.8962264f);
                GetComponent<EnemyFollow>().frozenMove = true; //stops the movement
                GetComponent<EnemyFollow>().frozenTurn = true;
                GetComponent<EnemyFollow>().frozenAnim = true;
                GetComponent<EnemyAttack>().frozen = true; //stops the turning and attacking
                runFreeze = false;
            }
            if (freezeTimer >= 5) //negate all effects of freeze and stop from running again
            {
                transform.GetChild(1).gameObject.SetActive(false);
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);

                GetComponent<EnemyFollow>().frozenMove = false; //stops the movement
                GetComponent<EnemyFollow>().frozenTurn = false;
                GetComponent<EnemyFollow>().frozenAnim = false;
                //GetComponent<EnemyFollow>().moveSlow = false;
                GetComponent<EnemyFollow>().speedConstant = 50;
                GetComponent<EnemyAttack>().frozen = false; //stops the turning and attacking
                runFreeze = true;
                freeze = false;
                freezeTimer = 0f;

            }

        }

        if (gravitronBurn)
        {
            if (hp <= 0)
            {
                Instantiate(goldSpawn, goldTransform.position, goldTransform.rotation);
                //GameObject.FindWithTag("Spawner").GetComponent<Spawner>().amountAlive -= 1;
                Destroy(gameObject);
            }
            gravitronTimer += Time.deltaTime;

            if (gravitronTimer >= .3)
            {
                if (runGrav)
                {
                    hp -= 1;
                    runGrav = false;
                }


            }
        }

        if (phantom)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.7924528f, 0f, 0.3008287f);
        }
        if (phantomFix)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        }

        if (plasma)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            plasmaTimer += Time.deltaTime;

            if (plasmaTimer > .8)
            {
                transform.GetChild(2).gameObject.SetActive(false);
                plasmaTimer = 0f;
                plasma = false;
            }

        }

    }
    //-------------------------------------------

    //detects collision and assigns initial damage
    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.tag == "BasicProjectile")
        {
            //                if(other.collision.tag != "Attack")
            //{

            //            }


            hp -= 1;
        }
        else if (col.gameObject.tag == "FireProjectile")
        {
            hp -= 1;

            burn = true;

        }
        else if (col.gameObject.tag == "IceProjectile")
        {
            freeze = true;
        }
        //else if(col.gameObject.tag == "Graviton")
        //{
        //    Debug.Log("Gravitron");
        //}
        else if (col.gameObject.tag == "GravitronBurn")
        {
            gravitronBurn = true;
            //inGravitron = true;
        }
        else if (col.gameObject.tag == "Phantom")
        {
            phantom = true;
            phantomFix = false;
            hp -= 1;

        }
        else if (col.gameObject.tag == "Plasma")
        {
            plasma = true;

            hp -= 3;

        }
        else if (col.gameObject.tag == "MegaFB")
        {
            MegaFB = true;
        }
        if (hp <= 0)
        {
            Instantiate(goldSpawn, goldTransform.position, goldTransform.rotation);
            //GameObject.FindWithTag("Spawner").GetComponent<Spawner>().amountAlive -= 1;
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Phantom")
        {
            phantom = false;
            phantomFix = true;
        }
    }


    //---------------------------------------------
}
