using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;//we register for OnSwipe - the callback is below
    }

    private void SwipeDetector_OnSwipe(SwipeData data)//in the callback we log out the direction
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
      
    }
}