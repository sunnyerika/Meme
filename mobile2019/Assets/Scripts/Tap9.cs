using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap9 : MonoBehaviour
{
    [SerializeField]
    private GameObject tweet;
    [SerializeField]
    private GameObject bird;
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
         Spawn();
         Destroy(gameObject);
       

    }

    void Spawn()
    {
        Vector3 tweetPosition = new Vector3(1f, 2f, 0f);
        Vector3 birdPosition = new Vector3((transform.position.x), (transform.position.y +1f));
        //Instantiate(tweet, transform.position, transform.rotation);//where we want to spawn it = position of spawner
        Instantiate(tweet, tweetPosition, transform.rotation);                                  //Instantiate(tweet, transform.position, transform.rotation, spawnParent);//spawn as a child gameObject of the parent - 
                                                                                                //spawned objects destroyed after used
                                                                                                //Instantiate(bird, transform.position, transform.rotation);
        Instantiate(bird, birdPosition, transform.rotation);


    }
}
