using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public bool run = false;

  
	// Use this for initialization
	void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
        if (run)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
	}
}
