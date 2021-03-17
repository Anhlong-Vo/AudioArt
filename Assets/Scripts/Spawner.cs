using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject notes;
    public GameObject timingCircle;
    public float beat;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (timer > beat)
        {
            Vector3 spawn = new Vector3(Random.Range(-1f, 2f), Random.Range(1f, 2f), 15f);
            Vector3 target = new Vector3(spawn.x, spawn.y, 2f);

            GameObject note = Instantiate(notes, spawn, Quaternion.identity);
            //GameObject circle = Instantiate(timingCircle, target, Quaternion.identity);

            timer -= beat;

        }
        timer += Time.deltaTime;
        
    }

}
