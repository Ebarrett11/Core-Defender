using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGravBurn : MonoBehaviour {

    public bool destroy = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (destroy)
        {
            Destroy(gameObject);
        }	
	}
}
