using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade4 : MonoBehaviour
{    // Start is called before the first frame update
    bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;
    public GameObject bladeTrailPrefab;
    private GameObject currentBladeTrail;

    Vector2 previousPosition;
    public float minCuttingVelocity = 0.001f;

    CircleCollider2D circleCollider;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
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

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }
        previousPosition = newPosition;
    }

    void StartCut()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        circleCollider.enabled = false;
    }

    void StopCut()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something collided");
        Destroy(other.gameObject);

    }
}

