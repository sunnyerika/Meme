using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInput : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPanel,tweetPanel;
    public Sprite[] tweets;
    public GameObject Bird;
    public Sprite OnDemand;

    [SerializeField]
    private float margin;

    private Vector2 mousePosition, startPos;
    private int index;
    private GameObject clickedObject;
    private Sprite image;
    [SerializeField]
    private float offset,swipeMultiplier=25f,swipeSpeed=10f;
    void Start()
    {
        Onspawn();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit= Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag.Equals("Bird"))
                {
                    myPanel.SetActive(true);
                    tweetPanel.GetComponent<Image>().sprite = image;
                    tweetPanel.GetComponent<RectTransform>().position = new Vector3 (0,tweetPanel.GetComponent<RectTransform>().position.y, tweetPanel.GetComponent<RectTransform>().position.z);
                    tweetPanel.SetActive(true);
                }
                else if (hit.collider.gameObject.name.Equals("Tweet"))
                {
                    clickedObject = hit.collider.gameObject;
                    startPos = new Vector2(clickedObject.transform.position.x, clickedObject.transform.position.y);
                    offset = mousePosition.x- clickedObject.GetComponent<RectTransform>().position.x;
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
        if (Input.GetMouseButtonUp(0)) {
            Debug.Log(clickedObject);
            if (clickedObject!=null) {
                Vector2 destPos = new Vector2((clickedObject.transform.position.x + (offset * swipeMultiplier)), clickedObject.transform.position.y);
               
                clickedObject.transform.position= Vector2.Lerp(startPos, destPos, swipeSpeed * Time.deltaTime);
                myPanel.SetActive(false);
                if (offset > margin && index < 3) // Towards right
                {
 
                   
                        offset = 0f;
                        Bird.SetActive(false);
                        tweetPanel.SetActive(false);
                        Respawn();
                    
                    /*else
                    {
                        offset = 0f;
                        //Bird.GetComponent<SpriteRenderer>().sprite = OnDemand;
                        tweetPanel.SetActive(false);
                        Respawn();
                        /*float frac = animateReady();
                        animate(frac);
                    }*/

                }
                else if (offset < -margin) // Towards left
                {
                    if (index >= 3) 
                    {
                        offset = 0f;
                        Bird.SetActive(false);
                        tweetPanel.SetActive(false);
                        Respawn();
                    }
                    /*else
                    {
                        offset = 0f;
                        //Bird.GetComponent<SpriteRenderer>().sprite = OnDemand;
                        tweetPanel.SetActive(false);
                        Respawn();
                        /*float frac = animateReady();
                        animate(frac);
                    }*/
                }

            }

        }
        /*void animate(float alpha)
        {
            alpha += alpha;        
            Bird.transform.position = Vector3.Lerp(curPos,finalPos,alpha);
        }*/
   
 
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
        Bird.transform.position = new Vector3(11f, 1062f, -150f);
        Bird.SetActive(true);
        Onspawn();
    }
    /*private float animateReady()
    {
        Vector3 curPos = new Vector3(Bird.transform.position.x, Bird.transform.position.y, Bird.transform.position.z);
        Vector3 finalPos = new Vector3(curPos.x, -1000, curPos.z);
        float fraction = (finalPos.y - curPos.y) / 10;
        return fraction;
    }
    private void OnDeath()
    {
        Onspawn();
    }*/

 
}
