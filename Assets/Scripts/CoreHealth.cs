using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreHealth : MonoBehaviour {
    public int health = 100;

    private SpriteRenderer img;
    // Use this for initialization
    void Start () {
        img = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            SceneManager.LoadScene(1);
            Destroy(gameObject);
        } 
	}

    void OnGUI()
    {
        //gui that will make labels and images appear


        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 40;
        textStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(5, 165, 20, 20), "Core HP: " + health, textStyle);



        

    }
}
