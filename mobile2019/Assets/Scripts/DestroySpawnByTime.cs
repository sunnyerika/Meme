﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawnByTime : MonoBehaviour
{

    public float lifeTime; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
