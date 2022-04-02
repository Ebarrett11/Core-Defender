using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public GameObject explosion;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("space"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        
	}
}
