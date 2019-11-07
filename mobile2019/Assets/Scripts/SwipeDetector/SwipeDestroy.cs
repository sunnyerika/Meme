using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;

    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log("SwipeAndDestroy: " );
        Destroy(gameObject);
    }

}
