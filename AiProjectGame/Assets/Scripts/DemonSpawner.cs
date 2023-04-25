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
    public float timeDelay = 2f ;

    //converting strings to variables
    //private string Spawnfunction = "SpawnFunction";

    // Start is called before the first frame update
    void Start()
    {
        //spawnSoundSourse = gameObject.GetComponent<AudioSource>();
        //InvokeRepeating(Spawnfunction, startTime, timeDelay);
        StartCoroutine("SpawnPrefabWithDelay");
    }

    // Update is called once per frame
    void Update()
    {
        //_timeDelayforDemons = DDA.timeDelay;
        spawnPosition.y = Random.Range(-5, 5);
        spawnPosition.x = Random.Range(-5, 5);
    }

   /* void SpawnFunction()
    {
        Instantiate(objectToBeSpawned, spawnPosition, spawnRotation);

        spawnSoundSourse.clip = spawnSound;
        spawnSoundSourse.Play();
    }*/

    IEnumerator SpawnPrefabWithDelay()
    {
        while (true)
        {
            Instantiate(objectToBeSpawned, spawnPosition, spawnRotation);
            yield return new WaitForSecondsRealtime(timeDelay);
        }
    }
}
