using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Vector3 target;
    public bool canBeHit = false; // canBeHit indicates when to hit the note for a perfect hit

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(transform.position.x, transform.position.y, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        // Note spawns and quickly moves towards the target position
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime*6);

        //Destroy(transform.gameObject, 4f);
    }

    // When the timing circle collides with the note object, canBeHit is true


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hit Note")
        {
            canBeHit = true;
        }
    }
}
