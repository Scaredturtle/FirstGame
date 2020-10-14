using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherDudeMove : MonoBehaviour
{
    public float speed = 1f;                //Floating point variable to store the player's movement speed.

    public Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    Vector2 movement;
    bool ismoving;
    int countDistance;
    // Start is called before the first frame update
    void Start()
    {
        countDistance = 0;
        ismoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //check for previous input, if not currently moving, allow another move
        if(ismoving == false)
        {
            //Move Up
            if(Input.GetKey("w"))
            {
                movement.y = 1;
                ismoving = true;
            }
            //Move Down
            if(Input.GetKey("s"))
            {
                movement.y = -1;
                ismoving = true;
            }
            //Move Right
            if(Input.GetKey("d"))
            {
                movement.x = 1;
                ismoving = true;
            }
            //Move Left
            if(Input.GetKey("a"))
            {
                movement.x = -1;
                ismoving = true;
            }
        }
    }
    void FixedUpdate()
    {
        if(ismoving == true)
        {
            rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
            countDistance = countDistance +1;
            if(countDistance>32)
            {
                ismoving = false;
                countDistance = 0;
                movement.x = 0;
                movement.y = 0;
            }
        }
    }
}
