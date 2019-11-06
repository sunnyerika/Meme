using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startRocketPosition, endRocketPosition;

    private float flyTime;//time from the moment it started to move
    private float flightDuration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            
            if((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.75f)
            {
                StartCoroutine(Fly("left"));
                Debug.Log("horizontal swipe left");
            }

            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x > 1.75f)
            {
                Debug.Log("horizontal swipe right");
                //StartCoroutine(Fly("right"));
            }


        }
    }

    private IEnumerator Fly (string direction)
    {
        switch (direction)
        {
            case "left":
                flyTime = 0;
                startRocketPosition = transform.position;
                endRocketPosition = new Vector3(startRocketPosition.x - 1.75f, transform.position.y, transform.position.z);//y and z stay the same

                while(flyTime < flightDuration)
                {
                    flyTime += Time.deltaTime;
                    transform.position = Vector2.Lerp(startRocketPosition, endRocketPosition, flyTime / flightDuration);//interpolates between start and endposition
                    yield return null;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
