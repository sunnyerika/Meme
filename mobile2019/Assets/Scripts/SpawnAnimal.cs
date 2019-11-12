using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{

    public GameObject animalPrefab;
    public Sprite[] animalSprites;

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
        string animalName = animalSprite.name;

        GameObject newAnimal = Instantiate(animalPrefab);//animal class with the name
        newAnimal.name = animalName;
        newAnimal.GetComponent<Animal>().animalName = animalName;//access a variable from another script
        newAnimal.GetComponent<SpriteRenderer>().sprite = animalSprite;
    }
}
