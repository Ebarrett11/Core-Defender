using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaKnight : MonoBehaviour {

    public GameObject Knight;
    public GameObject spawnParticles;

    float spawnTimer;

    public float knightTTS = 10;
    private float staticKnightTTS;
    Transform tf;

    new Vector2 offsetSpawn;
    // Use this for initialization
    void Start () {
        tf = GetComponent<Transform>();
        staticKnightTTS = staticKnightTTS;
     
	}
	
	// Update is called once per frame
	void Update () {
        

        spawnTimer += Time.deltaTime;
        if (spawnTimer > knightTTS)
        {
            
            Instantiate(Knight, tf.position, Quaternion.identity);
            Instantiate(spawnParticles, tf.position, Quaternion.identity);
            //knightTTS = knightTTS + staticKnightTTS;
            spawnTimer = 0;
        }

    }
}
