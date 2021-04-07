using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollision : MonoBehaviour
{
    public bool canBeHit = false;

    public void SetHit(bool hit)
    {
        canBeHit = hit;
    }

    public bool GetHit()
    {
        if (gameObject.activeSelf == false)
        {
            return false;
        }
        return canBeHit;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.parent.parent.gameObject == this.transform.parent.parent.gameObject)
        {
            SetHit(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.parent.gameObject == this.transform.parent.parent.gameObject)
        {
            SetHit(false);
            
            
        }
    }

}
