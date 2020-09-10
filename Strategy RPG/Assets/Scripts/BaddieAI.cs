using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieAI : AIHandler
{
    public float sprintSpeed;
    public float sprintTimer;  //future thought
    float countdown;
    public float chooseDirection;
    float lessJitter;
    public Rigidbody2D rb;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        countdown = sprintTimer;
        lessJitter = chooseDirection;
    }

    // Update is called once per frame
    void Update()
    {
        //based on timer set when to generate new direction.
        lessJitter -= Time.deltaTime;
        if (lessJitter < 0)
        {
            movement.x = Random.Range(-1, 2);
            movement.y = Random.Range(-1, 2);
            lessJitter = chooseDirection;
        }


        countdown -= Time.deltaTime;
        if (countdown < countdown / 2) movement = movement * sprintSpeed;

        if(countdown < 0) countdown = sprintTimer;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
