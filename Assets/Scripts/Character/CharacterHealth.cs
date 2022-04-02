using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    public int health = 5;
    public int x = 0;
    public int y = 0;

    public float characterX = 0f;
    public float characterY = 0f;

    private int heartX = 10;

    public bool damageColor = false;
    float damageTimer = 0f;

    float fireTimer = 0;

    public Texture txtr;

    //public ParticleSystem hit;
    //public bool particlePlay;
    // Use this for initialization

    bool fixHealthGUI = false;
    void Start()
    {


    }


    // Update is called once per frame



    // Update is called once per frame
    void FixedUpdate()
    {

        if (health <= 0)
        {
            SceneManager.LoadScene(1);
            Destroy(gameObject);
            //SceneManager.LoadScene(2);
        }

        //if (particlePlay)
        //{
        //    hit.Play();
        //}

        if (damageColor)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().color = new Color(0.6320754f, 0f, 0.02474862f);

            damageTimer += Time.deltaTime;
            
            if(damageTimer >= .2)
            {
                
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
               
               
            }
            if(damageTimer >= .6)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                damageTimer = 0f;   
                damageColor = false;
            }

        }
        //Checks health to change heart GUI ------------
        //if (health == 1)
        //{


        //    //Checks health to change heart GUI ------------



        //    //----------------------------------------------
        //}


        //characterX = GameObject.Find("Player").GetComponent<>().;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "EnemyArrow")
        {
            damageColor = true;
            health -= 1;
            
        }

        if(col.gameObject.tag == "lava")
        {
            Destroy(gameObject);

        }
    }


    void OnGUI()
    {
        //gui that will make labels and images appear


        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 40;
        textStyle.normal.textColor = Color.white;


        if(fixHealthGUI == false)
        {
        GUI.Label(new Rect(5, 215, 20, 20), "Player HP: " + health, textStyle);
        }
       

        if(health != 10)
        {
            fixHealthGUI = true;
            GUI.Label(new Rect(5, 215, 20, 20), "Player HP: " + health, textStyle);

        }





    }

}

    //I commented this out
//=
//=
//=
//=
//=
//=
//=
//=
//=
//We can add this back in later I was just lazy

    //void OnGUI()
    //{
    //    //gui that will make labels and images appear


    //    //characterX = GameObject.Find("Player").GetComponent<>().;

    //    GUI.DrawTexture(new Rect(10, 10, 50, 50), txtr);
    //    GUI.DrawTexture(new Rect(70, 10, 50, 50), txtr);
    //    GUI.DrawTexture(new Rect(130, 10, 50, 50), txtr);
    //    GUI.DrawTexture(new Rect(130, 10, 50, 50), txtr);
    //}









    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Enemy")
    //    {



