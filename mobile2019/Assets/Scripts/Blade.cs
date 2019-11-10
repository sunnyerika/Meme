using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    bool isCutting = true;

    Rigidbody2D rb;

    Camera cam;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCutting)
        {
            UpdateCut();
        }
        
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);//of gameobject
        rb.position = newPosition; //the rigidbody attached ot the gameobject will be repositioned

    }

    void StartCut()
    {

    }

    void StopCut()
    {

    }
}
