using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public void GoToMoneyScene()
    {
        SceneManager.LoadScene("FailState");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game1");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
