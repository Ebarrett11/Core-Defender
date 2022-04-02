using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPull : MonoBehaviour {


    public Transform player;

    Transform Coin; 
	// Use this for initialization
	void Start () {
        Coin = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Coin.position = player.position;
	}
}
