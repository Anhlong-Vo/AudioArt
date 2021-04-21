using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Note : MonoBehaviour
{

    private void OnDisable()
    {
        //when note is deactivated, reset the timing circle to original scale
        transform.Find("TimingCircle").localScale = new Vector3(2.426883f, 2.426883f, 2.426883f);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 target;
        target = new Vector3(transform.position.x, transform.position.y, 2f);
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 4);
    }

    public void HitNote()
    {   
        try
        {
            if (GameObject.FindWithTag("Hit Note").GetComponent<CircleCollision>().GetHit())
            {
                //Debug.Log("PERFECT HIT");
                GameManager.instance.PerfectHit();
            }
            else
            {
                //Debug.Log("NOT PERFECT");
                GameManager.instance.GoodHit();
            }

            transform.gameObject.SetActive(false);

            
        }
        catch (NullReferenceException)
        {
            Debug.Log("ERROR");
        }
        
    }
}
