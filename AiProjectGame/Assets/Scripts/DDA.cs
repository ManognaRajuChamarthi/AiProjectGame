using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDA : MonoBehaviour
{
    public GameObject player;
    public GameObject demonSpawn;
    public PlayerController PlayerController;
    public DemonSpawner DemonSpawner;

    public int PlayerKills;
    public int PlayerDeaths;
    public float PlayerTimeBetwenShot;
    public float DemonTimeDelay;

    public int KtoD;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        demonSpawn = GameObject.FindWithTag("spawner");
        PlayerController = player.GetComponent<PlayerController>();
        DemonSpawner = demonSpawn.GetComponent<DemonSpawner>();
    }

    
    void Update()
    {
        //variables updating
        PlayerKills = PlayerController.kills;
        PlayerDeaths = PlayerController.deaths;
        

        KtoD = PlayerKills / (PlayerDeaths+1);

        if(KtoD > 10 && KtoD <=20)
        {
            DemonSpawner.timeDelay = 1.5f;
            PlayerController.timeBetweenShots = 0.2f;
        }
        if (KtoD > 20)
        {
            DemonSpawner.timeDelay = 0.8f;
            PlayerController.timeBetweenShots = 0.11f; 
        }

        
        
    }
}
