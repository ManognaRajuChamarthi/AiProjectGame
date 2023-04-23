using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpawner : MonoBehaviour
{
    [HeaderAttribute("Instantiations")]
    public GameObject objectToBeSpawned;
    public Vector2 spawnPosition;
    public Quaternion spawnRotation;
    public AudioClip spawnSound;
    public AudioSource spawnSoundSourse;


    [HeaderAttribute("Call Function Settings")]
    public float startTime;
    public float timeDelay;

    //converting strings to variables
    private string Spawnfunction = "SpawnFunction";

    // Start is called before the first frame update
    void Start()
    {
        spawnSoundSourse = gameObject.GetComponent<AudioSource>();
        InvokeRepeating(Spawnfunction, startTime, timeDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnFunction()
    {
        Instantiate(objectToBeSpawned, spawnPosition, spawnRotation);

        spawnSoundSourse.clip = spawnSound;
        spawnSoundSourse.Play();
    }
}