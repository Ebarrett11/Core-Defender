using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public double speed = 50.0;
    public double speedConstant;

    public bool moveSlow = false;
    public bool frozenMove = false;
    public bool frozenTurn = false;
    public bool frozenAnim = false;
    int frozenCount = 0;
    int moveTowardsCount = 0;

    Vector2 frozenPosition;

    private Transform target;

    private Vector3 rotateAmount;

    private Animator anim;
    Rigidbody2D rb;

    float frozenTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedConstant = speed;
        anim = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {





        if (frozenTurn == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.up = target.position - transform.position;
        }
        if (frozenMove)
        {

            frozenTimer += Time.deltaTime;


            if (frozenTimer >= 0 && frozenCount == 0)
            {
                anim.SetBool("Attack", false);
                speedConstant /= 1.5;
                frozenCount += 1;
            }
            else if (frozenTimer >= .4 && frozenCount == 1)
            {

                speedConstant /= 1.2;
                frozenCount += 1;
            }
            else if (frozenTimer >= .8 && frozenCount == 2)
            {

                speedConstant /= 1.2;
                frozenCount += 1;
            }
            else if (frozenTimer >= 1.2 && frozenCount == 3)
            {

                speedConstant /= 1.2;
                frozenCount += 1;
            }
            else if (frozenTimer >= 1.6 && frozenCount == 3)
            {

                speedConstant /= 1.2;
                frozenCount += 1;
            }
            else if (frozenTimer >= 2.0 && frozenCount == 4)
            {

                speedConstant = 0;
                frozenCount = 0;
                frozenTimer = 0f;



            }
        }

        if (moveSlow)
        {
            speed = (speedConstant / 8) + speedConstant / 16;
        }
        if (moveSlow == false)
        {
            speed = speedConstant;
        }
        if (frozenMove == false)
        {
            moveTowardsCount = 0;
            transform.position = Vector2.MoveTowards(transform.position, target.position, (float)speed * Time.deltaTime);
        }
        if (frozenMove == true)
        {
            if (moveTowardsCount == 0)
            {
                frozenPosition = target.position;
                moveTowardsCount += 1;
            }
            else if (moveTowardsCount == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, frozenPosition, (float)speed * Time.deltaTime);
            }

        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "water")
        {


            speedConstant = 25;
        }


        if (frozenAnim == false)
        {
            if (col.gameObject.tag == "Player")
            {
                moveSlow = true;
                //anim.SetBool("Attack", moveSlow);
            }
        }
        if (frozenAnim == true)
        {
            anim.SetBool("Attack", false);
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "water")
        {
            speedConstant = 50;
        }

        if (frozenAnim == false)
        {
            if (col.gameObject.tag == "Player")
            {
                moveSlow = false;
                //anim.SetBool("Attack", moveSlow);

            }
        }
    }
}