using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private GameObject bottom;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        bottom = GameObject.FindGameObjectWithTag("Bottom");
       rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(rb.position.y == bottom.GetComponent<Rigidbody2D>().position.y)
        {
            rb.isKinematic = true;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }
}
