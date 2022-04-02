using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour {

    float destroyTimer = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        destroyTimer += Time.deltaTime;

        if(destroyTimer >= .3)
        {
            Destroy(gameObject);
        }

	}
}
