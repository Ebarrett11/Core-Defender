using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour {
    //public bool tp1 = false;
    //public bool tp2 = false;

    //public bool test = false;
    //public int testing = 0;
    SpriteRenderer portalImage;
    
    public GameObject otherTP;


    public Rigidbody2D rb;

    //public bool active;
    ////public bool run = false;
    //public bool otherActive;

    public bool active = true;
    public int count = 0;

    private bool startTimer;
    

    float portalTimer = 0f;
    // Use this for initialization
    void Start () {
        portalImage = GetComponent<SpriteRenderer>();
       
        //otherTP.transform.position

        //tpScript.active = false;
        //nbullet = controlscript.nbullet; //You should also consider renaming your nbullet variable

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            count += 1;
            TeleporterScript tpScript = otherTP.GetComponent<TeleporterScript>();
            tpScript.count = count;

        }
        if (count == 1)
        {
            rb.position = otherTP.transform.position;
            startTimer = true; //timer starts here
            BoxCollider2D otherCol =  otherTP.GetComponent<BoxCollider2D>();
            otherCol.enabled = false;
            var tempColor = portalImage.color;
            tempColor.a = .5f;
            //portalImage.color = tempColor;
            //portalImage. = Color.blue;
            //start timer to set to 0 
        }
    }
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if(col.gameObject.tag == "player")
    //    {
    //        testing += 1;
    //    }
    //    if (col.gameObject.tag == "Player" && active == true && testing != 2)
    //    {
    //        rb.position = otherTP.transform.position;
    //        active = false;
    //        //run = true;
    //        testing = 0;

    //    }
    //}
    void Update()
    {

        
        if (startTimer)
        {
            portalTimer += Time.deltaTime;
            if (portalTimer >= 5)
            {
                count = 0;
                TeleporterScript tpScript = otherTP.GetComponent<TeleporterScript>();
                tpScript.count = count;
                startTimer = false;
                portalTimer = 0f;
                BoxCollider2D otherCol = otherTP.GetComponent<BoxCollider2D>();
                otherCol.enabled = true;
                //Debug.Log("made it");

                SpriteRenderer otherSprite = otherTP.GetComponent<SpriteRenderer>();
                var tempColor = otherSprite.color;
                tempColor.a = 1f;
                //BoxCollider2D selfCol = gameObject.GetComponent<BoxCollider2D>();
                //selfCol.enabled = true;

            }
        }   
    }

    // Update is called once per frame
    //   void Update () {
    //       if (active == false)
    //       {
    //           portalTimer += Time.deltaTime;
    //           if (portalTimer >= 1)
    //           {
    //               active = true;
    //               //run = false;
    //               portalTimer = 0;
    //           }
    //       }

    //}

    void FixedUpdate()
    {

    }
}
