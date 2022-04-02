using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {
    public float destroyTime;
    public bool destoryFade;

    float goldFade;

    AudioSource coinSound;

    float destroyTimer;
	// Use this for initialization
	void Start () {
        goldFade = destroyTime - 5;

        //coinSound = GetComponent<AudioSource>();
        //coinSound.Play(0);
	}
	
	// Update is called once per frame
	void Update () {
        destroyTimer += Time.deltaTime;
        if (destoryFade)
        {
            if(destroyTimer >= goldFade)
            {
           
                GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f, .5f);
            }
        }

        if(destroyTimer >= destroyTime)
        {
            Destroy(gameObject);
        }

       
	}


}
