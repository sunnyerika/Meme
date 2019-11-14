using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        
    }

    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag.Equals("Bottom"))
        {
            //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }

           
        
    }
    */

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Dead")
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }



    }
}

