using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float playerSpeed;           // Movement Speed of the player
    public GameObject laserBlastPrefab; // Prefab GameObject of the laser blasts our player will shoot
    public Transform firePoint;         // Location our player will fire laser blasts from
    public float timeBetweenShots;      // Time in seconds from when the player shoots until he can shoot again
    public float playerBound;

    private Rigidbody2D rb;             // Reference to the Rigidbody2D component of this GameObject
    private Vector2 leftStickInput;     // Current (X,Y) input of the left stick on the game controller
    private Vector2 rightStickInput;    // Current (X,Y) input of the right stick on the game controller
    private bool canShoot;              // True when the player is able to fire a shot

   
    void Start()
    {
        // Get the Rigidbody2D componenet attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // Our player is able to shoot from the beginning of the game
        canShoot = true;
    }

   
    void Update()
    {
        GetPlayerInput();
        PlayerBoundaries();
        
    }

    private void FixedUpdate()
    {

        Vector2 curMovement = leftStickInput * playerSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + curMovement);

        if (rightStickInput.magnitude > 0f)
        {
            Vector3 curRotation = Vector3.left * rightStickInput.x + Vector3.up * rightStickInput.y;

            Quaternion playerRotation = Quaternion.LookRotation(curRotation, Vector3.forward);

            rb.SetRotation(playerRotation);
        }
    }


    private void GetPlayerInput()
    {
        leftStickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

       

        rightStickInput = new Vector2(Input.GetAxis("R_Horizontal"), Input.GetAxis("R_Vertical"));


        if (Input.GetButton("Shoot") && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        
        canShoot = false;

        Instantiate(laserBlastPrefab, firePoint.position, transform.rotation);

        StartCoroutine(ShotCooldown());
    }

  
    IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void PlayerBoundaries()
    {
        if(transform.position.x > playerBound)
        {
            transform.position = new Vector2(playerBound, transform.position.y);
        }else if( transform.position.x < -playerBound)
        {
            transform.position = new Vector2(-playerBound, transform.position.y);
        }

        if (transform.position.y > playerBound)
        {
            transform.position = new Vector2(transform.position.x,playerBound);
        }
        else if (transform.position.y < -playerBound)
        {
            transform.position = new Vector2(transform.position.x,-playerBound);
        }
    }

    
}
