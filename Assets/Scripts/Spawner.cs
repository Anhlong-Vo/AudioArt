using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float beatTempo;
    
    private float timer;
    public GameObject notes;

    // Start is called before any of the Update methods is called the first time
    private void Start()
    {
        this.beatTempo = beatTempo / 60f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>beatTempo)
        {
            Vector3 spawn = new Vector3(Random.Range(-1f, 2f), Random.Range(1f, 2f), 10f);
            
            Instantiate(notes, spawn, Quaternion.identity);
            

            timer -= beatTempo;
        }
        timer += Time.deltaTime;
        


    }

}
