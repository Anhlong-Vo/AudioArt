using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteVisuals : MonoBehaviour
{
    public float lifetime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
