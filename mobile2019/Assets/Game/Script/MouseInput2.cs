using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInput2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPanel, tweetPanel, spawnPoint, overlayState, button_restart, button_shop;
    
    [Header("Tweets Sprites")]
    public Sprite[] tweets;

    [Header("Bird Sprites")]
    public GameObject bird, flyingBird, dropingBird;
    public Sprite deadBird;


    [SerializeField]
    private float margin;
    private float speed;
    [SerializeField]
    private float delay;

    private Vector2 mousePosition, startPos;
    private int index;
    private GameObject clickedObject, flyingBirdInstance, dropingBirdInstance;
    private Sprite image;
    private bool isLeft;
    private Vector3 flyVelocity;
    private Vector3 direction;
    private Vector3 velocity;

    private bool swipeLeft;
    private bool swipeRight;
    private bool fakeTweet = false;
    private bool realTweet = false;

    [SerializeField]
    [Header("Other Settings")]
    private float offset, swipeMultiplier = 25f, swipeSpeed = 10f;

    private int fails =11;

    void Start()
    {
        Onspawn();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (fails >= 12)
        {
            //overlayState = Instantiate(overlayState, bird.transform.position, bird.transform.rotation);
            //enterFailState();
            StartCoroutine(WaitToSpawn());

        }


        // Detecting If input hit something
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag.Equals("Bird")) //Show tweet if its a bird
                {
                    myPanel.SetActive(true);
                    tweetPanel.GetComponent<Image>().sprite = image;
                    tweetPanel.GetComponent<RectTransform>().position = new Vector3(0, tweetPanel.GetComponent<RectTransform>().position.y, tweetPanel.GetComponent<RectTransform>().position.z);
                    tweetPanel.SetActive(true);
                }
                else if (hit.collider.gameObject.name.Equals("Tweet")) //move tweet if dragged using finger
                {
                    clickedObject = hit.collider.gameObject;
                    startPos = new Vector2(clickedObject.transform.position.x, clickedObject.transform.position.y);
                    offset = mousePosition.x - clickedObject.GetComponent<RectTransform>().position.x;
                    Debug.Log(offset);
                }

            }

            else
            {
                //myPanel.SetActive(false);
                // tweetPanel.SetActive(false);
                Debug.Log(hit);
            }
        }
        if (Input.GetMouseButtonUp(0)) // Moving Tweet according to finger swipe and Checking for win and fail state
        {
            //Debug.Log(clickedObject);
            if (clickedObject != null)
            {
                Vector2 destPos = new Vector2((clickedObject.transform.position.x + (offset * swipeMultiplier)), clickedObject.transform.position.y);
                
                clickedObject.transform.position = Vector2.Lerp(startPos, destPos, swipeSpeed * Time.deltaTime);
                myPanel.SetActive(false);

                checkSwipeDirection();
                setFakeReal();
                respondToSwipe();
                
                
            }
        }

        if (flyingBirdInstance != null)
        {
            FlyTimeline();
        }

        
    }

    private void Onspawn()
    {
        SetRandomImage();
    }
    private void SetRandomImage()
    {
        index = Random.Range(0, tweets.Length);
        image = tweets[index];
    }
    private void DetectSwipe()
    {

    }
    private void Respawn()
    {
        tweetPanel.GetComponent<RectTransform>().position = new Vector3(0, tweetPanel.GetComponent<RectTransform>().position.y, tweetPanel.GetComponent<RectTransform>().position.z);
        bird.transform.position = new Vector3(11f, 1062f, -150f);
        //bird.transform.rotation = new Vector3(0f, 0f, 0f);
        bird.SetActive(true);
        clickedObject = null;
        Onspawn();
    }
    private void FlyAway()
    {
        Destroy(flyingBirdInstance);
        flyingBirdInstance = Instantiate(flyingBird, bird.transform.position, bird.transform.rotation);
        flyingBirdInstance.transform.localScale = bird.transform.localScale;
      
        bool isLeft = Mathf.Sign(flyingBirdInstance.transform.localScale.x) < 0;
        if (isLeft)
        {
            flyVelocity = new Vector3(-300, 100, 0);
        }
        else
        {
            flyVelocity = new Vector3(300, 100, 0);

        }
    }

    private void DropDown()
    {
        Vector3 localBirdPos = new Vector3(bird.transform.position.x, bird.transform.position.y,0);
        Destroy(flyingBirdInstance);
        dropingBirdInstance = Instantiate(dropingBird, localBirdPos, bird.transform.rotation);
        dropingBirdInstance.transform.localScale = bird.transform.localScale;
        fails++;
 
    }



    private void FlyTimeline()
    {
        flyingBirdInstance.transform.Translate(flyVelocity * Time.deltaTime);
    }


    public void actionForCorrectSwipe()
    {
        resetTweetPanel();
        FlyAway();
        Respawn();
    }

    public void actionForWrongSwipe()
    {
        resetTweetPanel();
        DropDown();
        Respawn();
    }

    public void resetTweetPanel()
    {
        bird.SetActive(false);
        offset = 0f;
        tweetPanel.SetActive(false);
    }


    public void checkSwipeDirection ()
    {
        if (offset > margin)
        {
            swipeRight = true;
        }
        else if(offset < -margin)
        {
            swipeLeft = true;
        }
    }

    public void setFakeReal()
    {
        if (index < 3)
        {
            realTweet = true;
        }
        if (index >= 3)
        {
            fakeTweet = true;
        }
    }

    public void respondToSwipe()
    {

        if (swipeRight)
        {
            if (realTweet)
            {
                actionForCorrectSwipe();
                realTweet = false;
                swipeRight = false;
            }
            else if (fakeTweet)
            {
                actionForWrongSwipe();
                fakeTweet = false;
                swipeRight = false;
             }
        } else if (swipeLeft)
        {
            if (realTweet)
            {
                actionForWrongSwipe();
                realTweet = false;
                swipeLeft = false;

            } 
            else if (fakeTweet)
            {
                actionForCorrectSwipe();
                fakeTweet = false;
                swipeLeft = false;
            }
        }

    }

    IEnumerator WaitToSpawn()
    {
        //create delay
        bird.SetActive(false);
        yield return new WaitForSeconds(delay);
        enterFailState();
        
    }

    public void enterFailState()
    {
        //StartCoroutine(WaitToSpawn());
        overlayState.SetActive(true);
        bird.SetActive(false);
    }


}
