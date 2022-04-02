using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour
{
    //public CircleCollider2D healthCircle;
    CircleCollider2D healthCircle;

    private bool attack = false;

    float timer = 0f;
    private bool startAttack = false;
    private bool exit = false;
    private int firstCount = 0;

    public bool frozen;

    public GameObject arrow;

    public float attackSpeed= 2;

    Transform tf;
    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        healthCircle = GameObject.Find("Player").GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (startAttack)
        {
            if (exit == false)
            {
                timer += Time.deltaTime;
            }


            if (timer >=  attackSpeed )
            {
                if (exit == false)
                {
                    Instantiate(arrow, tf.position, tf.rotation);
                    //GameObject.Find("Player").GetComponent<CharacterHealth>().damageColor = true;

                    ////GameObject.Find("Player").GetComponent<CharacterHealth>().particlePlay = true;
                    //GameObject.Find("Player").GetComponent<CharacterHealth>().health -= 1;
                    timer = 0f;
                    //firstCount = 1;
                }


            }
            //if (timer >= .65 && firstCount == 1)
            //{
            //    GameObject.Find("Player").GetComponent<CharacterHealth>().damageColor = true;
            //    GameObject.Find("Player").GetComponent<CharacterHealth>().health -= 1;
            //    timer = 0f;
            //}


        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (frozen == false)
        {
            attack = GetComponent<EnemyFollow>().moveSlow;
        }




        if (col == healthCircle && attack)
        {
            exit = false;
            startAttack = true;

            //get variable from other class

        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col == healthCircle)
        {

            exit = true;
            timer = 0f;
            firstCount = 0;
        }
    }
}
