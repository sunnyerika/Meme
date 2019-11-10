using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{

    public float delay;
    public GameObject objectToSpawn;

    //we could make the SpawnedObjects member public and drag it to the inspector, but we use a different option:
    private Transform spawnParent; //get a reference in Start()


    // Start is called before the first frame update
    void Start()
    {
        spawnParent = GameObject.Find("SpawnedObjects").transform; //name of the object in the inspector
        StartCoroutine(WaitToSpawn());//to loop
    
    }

    //coroutine for delay
    IEnumerator WaitToSpawn()
    {
        //create delay
        yield return new WaitForSeconds(delay);
        Spawn();
    }

    void Spawn()
    {
        //Instantiate(objectToSpawn, transform.position, transform.rotation);//where we want to spawn it = position of spawner
        Instantiate(objectToSpawn, transform.position, transform.rotation, spawnParent);//spawn as a child gameObject of the parent - 
        //spawned objects destroyed after used


        StartCoroutine(WaitToSpawn());//to loop
    }


}
