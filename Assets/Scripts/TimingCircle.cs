﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingCircle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Timing circle slowly shrinks in size
        transform.localScale -= new Vector3(Time.deltaTime*2, Time.deltaTime*2,  Time.deltaTime*2);

        if (transform.localScale.x < 0f)
        {
            Destroy(transform.gameObject);
        }

    }
}