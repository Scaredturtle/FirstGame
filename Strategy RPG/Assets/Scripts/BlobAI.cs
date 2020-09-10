using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobAI : AIHandler
{
    private bool Recenter;
    private float RecenterTimer;
    private float jitter;
    public float changeDirectionTimer;
    public Rigidbody2D rb;
    Vector2 movement;
    public Transform blobAnchorPoint;
    public float distanceFromCenter;

    // Start is called before the first frame update
    void Start()
    {
        jitter = changeDirectionTimer;
        Recenter = false;
        RecenterTimer = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, blobAnchorPoint.position) > distanceFromCenter)
        {
            Recenter = true;
        }
        else
        {
            jitter -= Time.deltaTime;
            if (jitter < 0) 
            {
                movement.x = Random.Range(-1, 2);
                movement.y = Random.Range(-1, 2);
                jitter = changeDirectionTimer;
            }
        }
    }

    void FixedUpdate()
    {
        if (Recenter == false)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
        else 
        {
            transform.position = Vector2.MoveTowards(transform.position, blobAnchorPoint.position, speed * Time.fixedDeltaTime);
            if (RecenterTimer > 0)
            {
                RecenterTimer--;
            }
            else 
            {
                Recenter = false;
                RecenterTimer = 20;
            }
        }
    }
}
