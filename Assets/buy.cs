using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buy : MonoBehaviour
{

    bool startTimer = false;
    bool notBoughtYet = true;

    public int price;

    float buytimer = 0f;

    public string weapon = "";


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer && notBoughtYet && GameObject.FindWithTag("Player").GetComponent<CharacterMovement>().coinCounter >= price)
        {
            
            buytimer += Time.deltaTime;

            if (buytimer >= 3)
            {

                notBoughtYet = false;
                GameObject.FindWithTag("Player").GetComponent<CharacterMovement>().coinCounter -= price;
                if (weapon == "b")
                {
                    GameObject.FindWithTag("Player").GetComponent<CharacterMovement>().b = true;
                }
                if (weapon == "c")
                {
                    GameObject.FindWithTag("Player").GetComponent<CharacterMovement>().c = true;
                }
                if (weapon == "d")
                {
                    GameObject.FindWithTag("Player").GetComponent<CharacterMovement>().d = true;
                }

            }
        }

    }

    //void OnTriggerEnter(Collider2D col)
    //{
    //    if (col.gameObject.tag == "player")
    //    {
    //        startTimer = true;              
    //    }
    //}

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "player")
    //    {
    //        startTimer = true;
    //    }

    //}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
        
            startTimer = true;
        }
    }
}