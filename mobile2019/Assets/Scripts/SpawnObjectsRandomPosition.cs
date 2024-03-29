﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsRandomPosition : MonoBehaviour
{
    public float range;
    public float delay;
    // public GameObject objectToSpawn;
    public GameObject[] objectsToSpawn;

    //we could make the SpawnedObjects member public and drag it to the inspector, but we use a different option:
    private Transform spawnParent; //get a reference in Start()


    // Start is called before the first frame update
    void Start()
    {
        //spawnParent = GameObject.Find("SpawnedObjects").transform; //name of the object in the inspector
        spawnParent = GameObject.Find("SpawnerRandomPosition").transform;
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
        //Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], transform.position, transform.rotation, spawnParent);//spawn as a child gameObject of the parent - 
        Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], new Vector3(transform.position.x + Random.Range(-range, range), transform.position.y), transform.rotation, spawnParent);
        //spawned objects destroyed after used


        StartCoroutine(WaitToSpawn());//to loop
    }


}
