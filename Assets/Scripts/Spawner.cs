using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    //width = 1000,-1000
    //height = 400 - =-400
    public int MaximumX = 1000;
    public int MinimumX = -1000;

    //idea- characters that attack the enemies - could use circle collider or ray cast in 360

    public int MaximumY = 400;
    public int MinimumY = -400;

    public GameObject Knight;
    public GameObject spawnParticles;
    public GameObject Archer;

    public GameObject CoreAttacker;
    public GameObject FinalBoss;

    float spawnTimer;

    SpriteRenderer spawnArea;


    public float knightTTS = 10;
    private float staticKnightTTS;
    public float coreAttackerTTS = 2;
    private float staticCoreAttackerTTS;
    public float archerTTS;
    private float staticArcherTTs;

    public int waveCount = 1;

    public int spawnAmount = 20;
    int staticSpawnAmount;

    public int amountAlive = 0;
    int spawnCount;
    
    


    int oncePerWave = 0;

    bool firstTimeRunning = true;

    bool bossSpawned = false;

    bool win = false;

    // Use this for initialization
    void Start(){
        staticKnightTTS = knightTTS;
        staticCoreAttackerTTS = coreAttackerTTS;
        staticArcherTTs = archerTTS;

        staticSpawnAmount = spawnAmount;
        //spawnArea = GameObject.Find("SpawnArea").GetComponent<SpriteRenderer>();
        //Debug.Log(spawnArea.sprite.size);
    }

    void OnGUI()
    {
        //gui that will make labels and images appear



        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 40;
        textStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(5, 85, 20, 20), "Wave Count: " + waveCount, textStyle);

        GUI.Label(new Rect(5, 125, 20, 20), "Alive: " + amountAlive, textStyle);

        if (win)
        {
            GUI.Label(new Rect(5, 250, 40, 40), "YOU WIN!!!!!: ", textStyle);
        }
       








    }

    // Update is called once per frameS
    void Update () {

 

        spawnTimer += Time.deltaTime;

        if (spawnCount >= spawnAmount && amountAlive <= 0)
        {
            waveCount += 1;
            spawnTimer = 0;
            knightTTS = staticKnightTTS;

        }

        if ( oncePerWave != waveCount)
        {

            if (firstTimeRunning == true)
            {

                firstTimeRunning = false;
            }
            else
            {
                spawnAmount += staticSpawnAmount;
            }

            //if(waveCount == 1)
            //{
            //    spawnAmount = 20;
            //}
            //if (waveCount == 2)
            //{
            //    spawnAmount = 40;
            //}
            //if (waveCount == 3)
            //{
            //    spawnAmount = 60;
            //}
            //if (waveCount >= 4)
            //{
            //    spawnAmount = 80;
            //}

            spawnCount = 0;
            oncePerWave += 1;
        }

        

        
        if(spawnTimer > knightTTS && spawnCount < spawnAmount)
        {
            
                  


                Vector3 position = new Vector3(Random.Range(MinimumX, MaximumX), Random.Range(MinimumY, MaximumY), 0);
                Instantiate(Knight, position, Quaternion.identity);
                Instantiate(spawnParticles, position, Quaternion.identity);
                spawnCount += 1;
                knightTTS = knightTTS + staticKnightTTS;

                if(spawnCount < spawnAmount)
            {
                if (waveCount >= 2)
                {
                    Vector3 position2 = new Vector3(Random.Range(MinimumX, MaximumX), Random.Range(MinimumY, MaximumY), 0);
                    Instantiate(CoreAttacker, position2, Quaternion.identity);
                    Instantiate(spawnParticles, position2, Quaternion.identity);
                    spawnCount += 1;
                    coreAttackerTTS = coreAttackerTTS + staticKnightTTS;
                }
            }

            if (spawnCount < spawnAmount)
            {
                if (waveCount >= 3)
                {
                    Vector3 position3 = new Vector3(Random.Range(MinimumX, MaximumX), Random.Range(MinimumY, MaximumY), 0);
                    Instantiate(Archer, position3, Quaternion.identity);
                    Instantiate(spawnParticles, position3, Quaternion.identity);
                    spawnCount += 1;
                    
                }
            }

            if (spawnCount < spawnAmount)
            {
                if (waveCount >= 5)
                {
                    if(bossSpawned == false)
                    {
                        Vector3 position3 = new Vector3(Random.Range(MinimumX, MaximumX), Random.Range(MinimumY, MaximumY), 0);
                        Instantiate(FinalBoss, position3, Quaternion.identity);
                        Instantiate(spawnParticles, position3, Quaternion.identity);
                        spawnCount += 1;
                        bossSpawned = true;
                    }
                   
                }

                if(waveCount >= 6)
                {
                    bool win = true;
                }
            }



            //spawnTimer = 0;
        }
         
        
        //if (spawnTimer > coreAttackerTTS)
        //{
        //    Vector3 position = new Vector3(Random.Range(MinimumX, MaximumX), Random.Range(MinimumY, MaximumY), 0);
        //    Instantiate(Knight, position, Quaternion.identity);
        //    spawnTimer = 0;
        //}
    }



    

}
