using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Note : MonoBehaviour
{

  
    public void HitNote()
    {   
        try
        {
            if (GameObject.FindWithTag("Hit Note").GetComponent<CircleCollision>().GetHit())
            {
                Debug.Log("PERFECT HIT");
            }
            else
            {
                Debug.Log("NOT PERFECT");
            }

            transform.gameObject.SetActive(false);

            GameManager.instance.NoteHit();
        }
        catch (NullReferenceException)
        {
            Debug.Log("ERROR");
        }
        
    }
}
