using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobAI : MonoBehaviour
{
    public float speed, changeDirectionTimer;
    private float jitter, RecenterTimer;
    private bool Recenter;
    public Rigidbody2D rb;
    Vector2 movement, AnchorPoint;
    //private Transform blobAnchorPoint;
    public float distanceFromCenter;

    // Start is called before the first frame update
    void Start()
    {
        jitter = changeDirectionTimer;
        Recenter = false;
        RecenterTimer = 20;
        AnchorPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, AnchorPoint) > distanceFromCenter)
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
            transform.position = Vector2.MoveTowards(transform.position, AnchorPoint, speed * Time.fixedDeltaTime);
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
