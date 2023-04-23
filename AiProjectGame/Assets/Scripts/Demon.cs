using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{

    public int hitPoints;
    public float moveSpeed;
    public GameObject player;

    private Animator myAnimator;
    private AudioSource hitSound;
    private AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        hitSound = GetComponent<AudioSource>();

        deathSound = Resources.Load<AudioClip>("Audio/DemonWail");

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hitPoints--;

            if (hitPoints <= 0)
            {
                hitSound.clip = deathSound;
                myAnimator.SetBool("Dead", true);

                hitSound.Play();
            }
        }

    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
