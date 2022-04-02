using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public int x;
    public int y;

    public int coinCounter = 0;

    public float playerSpeed = 4f;

    public float shotSpeed = 4f;
    private Rigidbody2D rb;
    private Transform playerTransform;
    private Transform shotSpawn;

    //public Transform airShotPrefab;

    public Transform shotPrefabA;
    public Transform shotPrefabB;
    public Transform shotPrefabX;
    public Transform shotPrefabY;

    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Vector2 oldMoveInput;

    private Vector2 lookInput;
    private Vector2 oldLookInput;

    private Vector2 shotInput;
    private Vector2 shotVelocity;

    private float degrees = 0f;
    private float moving = 0f;
    private float moveTimer = 0.3f;
    private float fireRate = 0.5f;
    private float airFireRate = 1f;

    private Animator anim;

    float PrimaryAttack;

    public float floatHeight;     // Desired floating height.
    public float liftForce;       // Force to apply when lifting the rigidbody.
    public float damping;         // Force reduction proportional to speed (reduces bouncing).

    string selection = "";

    public bool a = true;
    public bool b = false;
    public bool c= false;
    public bool d = false;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //PrimaryAttack = Input.GetAxis("PrimaryAttack");
        playerTransform = GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();

        shotSpawn = GameObject.Find("ShotSpawn").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        lookInput = oldLookInput; //Checks to see if the character has looked somewhere else


        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("1"))
        {
            selection = "a";
        }

        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("2"))
        {
            selection = "b";
        }

        if (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("3"))
        {
            selection = "x";
        }

        if (Input.GetKeyDown("joystick button 3") || Input.GetKeyDown("4"))
        {
            selection = "y";
        }



        if (Input.GetAxis("PrimaryAttack") == 1 || Input.GetKey("space"))
        {
            if (selection == "a" && a)
            {
                FireAttack();
            }
           
            if (selection == "b" && b)
            {
                IceAttack();
            }
            if (selection == "x" && c)
            {
                GravitronAttack();
            }
            if (selection == "y" && d)
            {
                PhantomAttack();
            }
        }

        //Debug.Log(PrimaryAttack);

       

        //if (Input.GetAxis("SecondaryAttack") == 1)
        //{
        //    airFireRate += Time.deltaTime;


        //    if (airFireRate >= 0.5)
        //    {
        //        AirShot();
        //        airFireRate = 0;
        //    }
        //}





        //Debug.Log(PrimaryAttack);


        //if(Input.GetAxis("SecondaryAttack") == 1)
        //{
        //    AirShot();
        //}



    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Gold")
        {
            
            Destroy(col.gameObject);

            coinCounter = coinCounter + 1;
            //source.PlayOneShot(coinSound);

        }

        if (col.gameObject.tag == "Special Gold")
        {

            Destroy(col.gameObject);

            coinCounter = coinCounter + 1000;
            //source.PlayOneShot(coinSound);

        }

        if (col.gameObject.tag == "water")
        {

            playerSpeed /= 2;
        }

        if (col.gameObject.tag == "Magic Trigger")
        {
            col.GetComponent<Trigger>().run = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "water")
        {
            playerSpeed *= 2;
        }
    }

    void FixedUpdate()
    {

        //DONT FORGET THIS IS HERE
        //    \

        //\
        //\

        //\
        //\
        //\

        //\

        //\


        fireRate += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit.collider != null)
        {

            // Calculate the distance from the surface and the "error" relative
            // to the floating height.
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = floatHeight - distance;


            // The force is proportional to the height error, but we remove a part of it
            // according to the object's speed.
            //float force = liftForce * heightError - rb.velocity.y * damping;

            //// Apply the force to the rigidbody.
            //rb.AddForce(Vector3.up * force);
        }

        //Logic for walking ---------------------------------
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * playerSpeed;
        rb.velocity = moveVelocity;
        //---------------------------------------------------


        //Logic for Looking/Aiming --------------------------
        lookInput = new Vector2(Input.GetAxisRaw("Attack Horizontal"), Input.GetAxisRaw("Attack Vertical"));


        //---------------------------------------------------


        shotInput = new Vector2(Input.GetAxisRaw("Attack Horizontal"), Input.GetAxisRaw("Attack Vertical"));

        //Logic for the walking animation ---------------------
        if (moveInput.x != 0) moving = 1f;
        else if (moveInput.y != 0) moving = 1f;
        else moving = 0f;
        anim.SetFloat("speed", moving);
        //-----------------------------------------------------




        //Rotating Sprite with Movement  ---------------------
        if (lookInput != oldLookInput)
        {
            degrees = Mathf.Atan2(lookInput.x, lookInput.y) / Mathf.PI * -180;
            transform.eulerAngles = new Vector3(0, 0, degrees);
        }

        if (lookInput == new Vector2(0, 0))
        {
            degrees = Mathf.Atan2(moveInput.x, moveInput.y) / Mathf.PI * -180;
            transform.eulerAngles = new Vector3(0, 0, degrees);
        }

        //----------------------------------------------------

        //Debug.Log(lookInput);

        //PrimaryAttack = Input.GetAxis("PrimaryAttack");

    }
    void OnGUI()
    {
        //gui that will make labels and images appear


        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 40;
        textStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(5, 5, 20, 20), "Coins: " + coinCounter, textStyle);



        if (selection == "a")
        {
            GUI.Label(new Rect(5, 45, 20, 20), "Spell: " + "1st Attack", textStyle);
        }
        if (selection == "b")
        {
            GUI.Label(new Rect(5, 45, 20, 20), "Spell: " + "2nd Attack", textStyle);
        }
        if (selection == "x")
        {
            GUI.Label(new Rect(5, 45, 20, 20), "Spell: " + "3rd Attack", textStyle);
        }
        if (selection == "y")
        {
            GUI.Label(new Rect(5, 45, 20, 20), "Spell: " + "4th Attack", textStyle);
        }


    }



    void FireAttack()
    {


        if (fireRate >= 0.3)
        {
            Instantiate(shotPrefabA, shotSpawn.position, transform.rotation);
            fireRate = 0;
        }
    }

    







    void IceAttack()

    {


        if (fireRate >= 0.3)
        {
            Instantiate(shotPrefabB, shotSpawn.position, transform.rotation);
            fireRate = 0;
        }
    }

    void GravitronAttack()
    {



        if (fireRate >= 0.3)
        {
            Instantiate(shotPrefabX, shotSpawn.position, transform.rotation);
            fireRate = 0;
        }
    }

    void PhantomAttack()
    {


        if (fireRate >= 0.3)
        {
            Instantiate(shotPrefabY, shotSpawn.position, transform.rotation);
            fireRate = 0;
        }


    }




    //void AirShot()
    //{
    //    airFireRate += Time.deltaTime;
    //    if(airFireRate >= 1.5) Instantiate(airShotPrefab, shotSpawn.position, transform.rotation); 
    //}



}



    //class: Character movement

    //variables
    //move speed
    //damage
    //

    //start
    //get the rigid body



//detect input from the right joystickk
//use the input to shoot in the direction pressed

    //update
    //detect input from the left joystick
    //apply movement

    //detect input from the right joystickk
    //use the input to shoot in the direction pressed


    
