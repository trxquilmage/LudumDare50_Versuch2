using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public static BeatManager instance;
    //länge eines Tacktes in S
    [Range(0,500)]
    public float BPM = 1;
    float startingTime;
    float lastBeatTime;


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
        int beats = Mathf.FloorToInt(pastTimeSinceLastBeat / BPM);
        lastBeatTime += beats * BPM;

        for (int i = 0; i < beats; i++)
        {
            OnBeat();
        }
    }
    void OnBeat() 
    {
        Debug.Log("Beat");
    }

}
