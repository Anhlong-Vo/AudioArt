using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingCircle : MonoBehaviour
{
    // speed of the timing circle
    private float speed;
    public GameObject missedEffect;

    // Start is called before any of the Update methods is called the first time
    private void Start()
    {
        this.speed = 111f / 60f;
    }

    // Update is called once per frame
    void Update()
    {

        // if timing circle scale is below zero, disable it
        if (transform.localScale.x < 0f)
        {

            //Destroy(transform.parent.gameObject);
            //Destroy(transform.gameObject);
            transform.parent.gameObject.SetActive(false);
            Instantiate(missedEffect, transform.parent.position, missedEffect.transform.rotation);
            GameManager.instance.NoteMissed();
        }

        else
        {
            // decrease timing circle scale      
            transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                
               
            if (transform.localScale.x < 0.4f)
            {
                // indicating that the timing circle is in a good hit position, not perfect hit anymore
                try
                {
                    GameObject.FindWithTag("Hit Note").GetComponent<CircleCollision>().SetHit(false);
                }

                catch (NullReferenceException)
                {
                    transform.gameObject.SetActive(false);

                }


            }
        }
        

    }

}
