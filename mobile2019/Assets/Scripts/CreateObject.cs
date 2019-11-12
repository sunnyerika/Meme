using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{

    public Transform Spawnpoint;//
    public GameObject Prefab;

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation); //when object spawns it can fall off if it's a rigidbody
    }
    */


    private void OnMouseDown()//on tap
    {
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
