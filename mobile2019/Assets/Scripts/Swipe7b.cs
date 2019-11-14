using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Swipe7b : MonoBehaviour
{

    private Vector2 startTouchPosition, endTouchPosition;
    private Rigidbody2D rb;
    private float jumpForce = 700f;
    private bool jumpAllowed = false;

    public static bool swipedRight = false;
    public static bool swipedLeft = false;
    public bool destroyable = true;

    // If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
    public const float MAX_SWIPE_TIME = 0.5f;
    Vector2 startPos;
    float startTime;
    // Factor of the screen width that we consider a swipe
    // 0.17 works well for portrait mode 16:9 phone
    public const float MIN_SWIPE_DISTANCE = 0.17f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        swipedRight = false;
        swipedLeft = false;
        SwipeCheck();
    }

    private void FixedUpdate()
    {
        JumpIfAllowed();
    }

    /*
    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.y > startTouchPosition.y)
            {
                jumpAllowed = true;
                //Destroy(gameObject);
            }
            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.75f)
            {
                //StartCoroutine(Fly("left"));
                Debug.Log("horizontal swipe left");
                Destroy(gameObject);
            }

            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x > 1.75f)
            {
                Debug.Log("horizontal swipe right");
                //StartCoroutine(Fly("right"));
            }
        }
    }*/

    private void SwipeCheck()
    {
        Touch t = Input.GetTouch(0);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            //startTouchPosition = Input.GetTouch(0).position;
            startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
            startTime = Time.time;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
            //endTouchPosition = Input.GetTouch(0).position;
            Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

            if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                return;

            if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
            { // Horizontal swipe
                if (swipe.x > 0)
                {
                    swipedRight = true;
                }
                else
                {
                    swipedLeft = true;
                    Destroy(gameObject);
                }
            }

            if (endTouchPosition.y > startTouchPosition.y)
            {
                jumpAllowed = true;
                //Destroy(gameObject);
            }
            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.75f)
            {
                //StartCoroutine(Fly("left"));
                Debug.Log("horizontal swipe left");
                //Destroy(gameObject);
            }

            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x > 1.75f)
            {
                Debug.Log("horizontal swipe right");
                //StartCoroutine(Fly("right"));
            }
        }
    }


    private void JumpIfAllowed()
    {
        if (jumpAllowed)
        {
            //rb.AddForce(Vector2.up * jumpForce);
            // Destroy(gameObject);
            jumpAllowed = false;
        }
    }
}
