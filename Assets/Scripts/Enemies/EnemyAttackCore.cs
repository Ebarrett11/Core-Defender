using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCore : MonoBehaviour
{
    //public CircleCollider2D healthCircle;
    BoxCollider2D healthSquare;

    public bool attack = false;

    float timer = 0f;
    private bool startAttack = false;
    public bool exit = false;
    public int firstCount = 0;
    // Use this for initialization
    void Start()
    {
        healthSquare = GameObject.Find("Core").GetComponent<BoxCollider2D>();
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


            if (timer >= .85 && firstCount == 0)
            {
                if (exit == false)
                {
                    //fix later
                    GameObject.Find("Core").GetComponent<CoreHealth>().health -= 1;
                    timer = 0f;
                    firstCount = 1;
                }


            }
            if (timer >= .65 && firstCount == 1)
            {
                //fix later
               GameObject.Find("Core").GetComponent<CoreHealth>().health -= 1;
                timer = 0f;
            }


        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {


        attack = GetComponent<EnemyFollowCore>().moveSlow;
        if (col == healthSquare && attack)
        {
            exit = false;
            startAttack = true;

            //get variable from other class

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col == healthSquare)
        {

            exit = true;
            timer = 0f;
            firstCount = 0;
        }
    }
}
