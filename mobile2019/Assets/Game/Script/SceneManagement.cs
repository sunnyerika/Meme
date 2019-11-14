using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject initBird;
    private Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Bird")
                {
                    SceneManager.LoadScene("Game");
                }
            }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "ButtonRestart")
                {
                    SceneManager.LoadScene("Game1");
                }
            }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "ButtonShop")
                {
                    SceneManager.LoadScene("MoneyMoney");
                }
            }

        }
    }
}
