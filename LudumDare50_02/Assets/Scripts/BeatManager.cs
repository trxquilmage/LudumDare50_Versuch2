using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public static BeatManager instance;
    //länge eines Tacktes in S
    [Range(0, 500)]
    public float BPM = 120;
    float beatLength { get { float value = BPM / 60; return value; } }
    float startingTime;
    float lastBeatTime;
    [SerializeField] [Range(0, 1)] float isOnBeatTolerance = 0;
    [SerializeField] [Range(0, 10)] int PauseBetweenSteps = 2;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        Gamestart();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        IsOnBeat();
        CheckForBeat();
    }


    void Gamestart()
    {
        startingTime = Time.time;
    }
    public void CheckForBeat()
    {
        float currentTime = Time.time - startingTime;
        float pastTimeSinceLastBeat = currentTime - lastBeatTime;
        int beats = Mathf.FloorToInt(pastTimeSinceLastBeat / beatLength);
        lastBeatTime += beats * beatLength;

        for (int i = 0; i < beats; i++)
        {
            OnBeat();
        }
    }
    void OnBeat()
    {
        Debug.Log("Beat");
    }





    public bool IsOnBeat() 
    {
        float targetBeatTime = lastBeatTime;
        float currentTime = Time.time - startingTime;
        if (currentTime <= targetBeatTime + isOnBeatTolerance || currentTime >= targetBeatTime + beatLength - isOnBeatTolerance)
        {
            Debug.Log("IsOnBeat");
            return true;
        }
        else
        {
            Debug.Log("NOPE");
            return false;
        }

    }
}
