using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    public GameObject boundsLeft;
    public GameObject boundsRight;
    public float offsets;
    void Start()
    {
        gameObject.transform.position = new Vector3(Random.Range(boundsLeft.transform.position.x+offsets, boundsRight.transform.position.x-offsets),transform.position.y, transform.position.z);
    }

    
}
