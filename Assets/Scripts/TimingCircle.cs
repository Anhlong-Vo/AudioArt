using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingCircle : MonoBehaviour
{
    public float beatTempo;
    // Start is called before any of the Update methods is called the first time
    private void Start()
    {
        this.beatTempo = beatTempo / 60f;
    }
    // Update is called once per frame
    void Update()
    {
        
        // Timing circle shrinks in size

        if (transform.localScale.x < 0f)
        {
            
            //Destroy(transform.parent.gameObject);
            //Destroy(transform.gameObject);
            transform.parent.gameObject.SetActive(false);
            GameManager.instance.NoteMissed();
        }

        else
        {
            transform.localScale -= new Vector3(beatTempo * Time.deltaTime, beatTempo * Time.deltaTime, beatTempo * Time.deltaTime);
            if (transform.localScale.x < 0.2f)
            {
                
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
