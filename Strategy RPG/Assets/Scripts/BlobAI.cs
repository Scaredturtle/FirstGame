using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobAI : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Random.Range(-1, 2);
        movement.y = Random.Range(-1, 2);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
