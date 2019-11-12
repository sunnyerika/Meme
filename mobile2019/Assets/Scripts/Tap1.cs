using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap1 : MonoBehaviour
{
    [SerializeField]
    private GameObject tweet;
    //private Transform spawnParent;

    // Start is called before the first frame update
    void Start()
    {
       // spawnParent = GameObject.Find("SpawnedTweets").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()//on tap
    {
        Destroy(gameObject);
        Spawn();

    }

    void Spawn()
    {
        Instantiate(tweet, transform.position, transform.rotation);//where we want to spawn it = position of spawner
        //Instantiate(tweet, transform.position, transform.rotation, spawnParent);//spawn as a child gameObject of the parent - 
        //spawned objects destroyed after used


        
    }
}
