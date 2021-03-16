using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    private Vector3 target;

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

        Destroy(transform.gameObject, 3f);
    }
}
