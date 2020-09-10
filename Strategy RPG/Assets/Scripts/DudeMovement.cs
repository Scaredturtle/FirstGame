using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeMovement : MonoBehaviour
{
    public float speed = 1f;                //Floating point variable to store the player's movement speed.

    public Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    Vector2 movement;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        //rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);

        /*

        Trying a modified verion of this code which might stop the sliding. Waiting for Taylor's input before deciding how to handle movement.

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);
        */
    }
}
