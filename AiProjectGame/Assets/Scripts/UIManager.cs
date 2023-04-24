using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Spawnner;
    public Text stats;
    public PlayerController Player;
    public DemonSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        stats = gameObject.GetComponent<Text>();
        player = GameObject.FindWithTag("Player");
        Spawnner = GameObject.FindWithTag("spawner");
        Player = player.GetComponent<PlayerController>();
        spawner = Spawnner.GetComponent<DemonSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

        stats.text = "health: " + Player.health.ToString() + "\nKills: " + Player.kills.ToString()
            + "\nDeaths: " + Player.deaths.ToString() + "\nTime Between Shots: " + Player.timeBetweenShots.ToString()
            + "\nDemon Spawn Time: " + spawner.timeDelay.ToString();
    }
}
