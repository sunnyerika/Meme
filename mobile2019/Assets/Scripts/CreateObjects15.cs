using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects15 : MonoBehaviour
{

    public Transform Spawnpoint;//
    public GameObject Prefab;
    public Sprite[] animalSprites;
    //string animalName;
    //Sprite animalSprite;
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation); //when object spawns it can fall off if it's a rigidbody
    }
    */


    private void OnMouseDown()//on tap
    {
        //Instantiate(Prefab);
        MakeRandomAnimal();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MakeRandomAnimal()
    {
        int arrayIndex = Random.Range(0, animalSprites.Length);//inclusive first, exclusive last
        Sprite animalSprite = animalSprites[arrayIndex];

        /*
        for(int i = 0; i< animalSprites.Length; i++)
        {
            animalSprite = animalSprites[i];
            animalName = animalSprite.name;
            GameObject newAnimal = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
            newAnimal.name = animalName;
            newAnimal.GetComponent<Animal>().animalName = animalName;//access a variable from another script
            newAnimal.GetComponent<SpriteRenderer>().sprite = animalSprite;
        }
        */

        string animalName = animalSprite.name;

        
        GameObject newAnimal = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
        newAnimal.name = animalName;
        newAnimal.GetComponent<Animal>().animalName = animalName;//access a variable from another script
        newAnimal.GetComponent<SpriteRenderer>().sprite = animalSprite;
        
    }
}
