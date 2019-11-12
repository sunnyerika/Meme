using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade3 : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (Input.GetMouseButtonDown(0)) //left
        {
            StartCut();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCut();
        }

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
        isCutting = true;
    }

    void StopCut()
    {
        isCutting = false;
    }
}
