using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    // current position of song (in seconds)
    public float songPosition;

    // current position of song (in beats)
    public float songPosInBeats;

    // the duration of a beat
    public float secPerBeat;

    //how much time (in seconds) has passed since the song started
    public float dsptimesong;

    //beats per minutes of a song
    public float bpm;

    //keep all postion-in-beats of notes in the song
    public float[] notes;

    //index of the next note to be spawned
    int nextIndex = 0;

    // song to play
    public AudioSource music;

    public float offset;

    public static SongManager instance;

    public static bool paused = false;
    public static float pauseTimeStamp = -1f;
    private float pausedTime = 0f;

    public GameObject pauseCanvas;

    public bool songEnd = false;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        paused = false;
        pauseTimeStamp = -1f;

        //calculate how many seconds in one beat
        secPerBeat = 60f / bpm;

        // record time when song starts
        dsptimesong = (float)AudioSettings.dspTime;

        // start the song
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            if (pauseTimeStamp < 0f)
            {
                pauseTimeStamp = (float)AudioSettings.dspTime;
                music.Pause();
                Time.timeScale = 0;
                pauseCanvas.SetActive(true);
            }
            return;

        }
        else if (pauseTimeStamp > 0f)
        {
            pausedTime += (float)AudioSettings.dspTime - pauseTimeStamp;
            music.Play();
            Time.timeScale = 1;

            pauseTimeStamp = -1f;
            pauseCanvas.SetActive(false);
        }

        // calculate position in seconds
        songPosition = (float)(AudioSettings.dspTime - dsptimesong - offset - pausedTime);

        //calculate postion in beats
        songPosInBeats = songPosition / secPerBeat;

        if (nextIndex < notes.Length && notes[nextIndex] < songPosInBeats)
        {
            //spawn note at random location 
            Vector3 spawn = new Vector3(Random.Range(-1f, 2f), Random.Range(1f, 2f), 10f);
            GameObject note = ObjectPool.instance.GetPooledObject();
            if (note != null)
            {
                note.transform.position = spawn;
                note.SetActive(true);
            }
            nextIndex++;
            
        }

        if (nextIndex >= notes.Length)
        {
            songEnd = true;
        }

        // reload back to the main menu when the song ends
        //if (!music.isPlaying)
        //{
            //SceneManager.LoadScene("VR");
        //}
    }       
}
