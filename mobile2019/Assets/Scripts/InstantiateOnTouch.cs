using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnTouch : MonoBehaviour
{

    [SerializeField]
    private GameObject[] prefabs;

    private int randomPrefab;
    private Touch touch;
    private Vector2 touchPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                randomPrefab = Random.Range(0, 2);
                Instantiate(prefabs[randomPrefab], touchPos, Quaternion.identity);
            }
        }
    }
}
