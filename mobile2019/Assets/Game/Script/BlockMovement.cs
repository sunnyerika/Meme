using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public Vector2 initialVelocity;
    public Vector2 acceleration;

    private Rigidbody2D rb;
    private float time = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    void FixedUpdate()
    {
        time += Time.deltaTime;
        Vector2 velocity = initialVelocity + time * acceleration;
        rb.AddForce(velocity);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounds" )
        {
            
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            if (gameObject.transform.GetChild(0) != null)
            {
                gameObject.transform.GetChild(0).transform.localScale = new Vector3(gameObject.transform.GetChild(0).transform.localScale.x * -1, gameObject.transform.GetChild(0).transform.localScale.y, gameObject.transform.GetChild(0).transform.localScale.z);
            }
            time = 0.0f;
            rb.velocity = Vector2.zero;
            initialVelocity.x = initialVelocity.x * -1.0f;
            acceleration.x = acceleration.x * -1.0f;
        }

    }
}
