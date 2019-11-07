using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    private Rigidbody2D rigidBody;//ghost
    private float dirX, dirY, moveSpeed;
    //public float minX, maxX, minY, maxY;

    [SerializeField]
    private GameObject pumpkin;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        SpawnPumpkin();
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;//arrowbuttons
        dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
    }

    private void FixedUpdate() //overridden
    {
        rigidBody.velocity = new Vector2(dirX, dirY);//move ghost
    }

    private void SpawnPumpkin()
    {
        bool pumpkinSpawned = false;
        
        while (!pumpkinSpawned)
        {
            Vector3 pumpkinPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-4f, 4f), 0f);//x, y
            //Vector3 pumpkinPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);//x, y

            if ((pumpkinPosition - transform.position).magnitude < 3)//keep a distance
            {
                continue;
            }
            else
            {
                Instantiate(pumpkin, pumpkinPosition, Quaternion.identity);
                pumpkinSpawned = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        SpawnPumpkin();
    }
}
