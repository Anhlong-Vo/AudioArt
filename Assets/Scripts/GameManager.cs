using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentScore;
    public int scorePerPerfectNote = 100;
    public int scorePerGoodNote = 50;

    
    public int currentMultiplier;

    // check if it meets the threshold or not
    public int multiplierTracker;

    // shows the thresholds when to increase the currentMultiplier
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiplierText;

    public float totalNotes;

    // number of notes hit early or late
    public float goodHits;

    // number of notes hit perfectly
    public float perfectHits;

    public float missedHits;

    public GameObject resultCanvas;
    // text values that need to be updated
    public TMP_Text perfectValue, goodValue, missedValue, percentageValue, rankValue, finalScoreValue;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (SongManager.instance != null && !SongManager.instance.music.isPlaying && !resultCanvas.activeInHierarchy && SongManager.instance.songEnd)
        {
            resultCanvas.SetActive(true);

            perfectValue.text = perfectHits.ToString();
            goodValue.text = goodHits.ToString();
            missedValue.text = missedHits.ToString();

            //float maxScore = 0;
            //for (int i=0; i < multiplierThresholds.Length; i++)
            //{
            //    for (int j = i; j < multiplierThresholds[i]; j++)
            //    {
            //        maxScore += scorePerPerfectNote * (i + 1);
            //    }
            //}

            //for (int k = multiplierThresholds[multiplierThresholds.Length-1]; k < totalNotes; k++)
            //{
            //    maxScore += scorePerPerfectNote * (multiplierThresholds.Length + 1);
            //}

            float goodAccuracy = 0;
            for (int i = 0; i < goodHits; i++)
            {
                goodAccuracy += 0.5f;
            }

            // 100% = all notes hit perfectly
            // good notes worth 0.5
            // perfect notes worth 1
            float percentHit = ((goodAccuracy + perfectHits) / totalNotes ) * 100f;
            percentageValue.text = percentHit.ToString("F1") + "%";

            if (percentHit > 95)
            {
                rankValue.text = "S";
            }
            else if (percentHit > 85)
            {
                rankValue.text = "A";
            }
            else if (percentHit > 70)
            {
                rankValue.text = "B";
            }
            else if (percentHit > 60)
            {
                rankValue.text = "C";
            }
            else if (percentHit > 50)
            {
                rankValue.text = "D";
            }
            else
            {
                rankValue.text = "F";
            }

            finalScoreValue.text = currentScore.ToString();
        }
    }

    public void NoteHit()
    {
        totalNotes++;
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }

        }

        scoreText.text = "Score: " + currentScore;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierText.text = "Multiplier: x" + currentMultiplier;

        totalNotes++;
        missedHits++;

    }
}
