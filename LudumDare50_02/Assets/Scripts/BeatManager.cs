using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public static BeatManager instance;
    //l�nge eines Tacktes in S
    [Range(0, 500)]
    public float BPM = 120;
    public float beatLength { get { float value = 1 / (BPM / 60); return value; } }
    [HideInInspector] public float startingTime;
    float lastBeatTime;
    [SerializeField] [Range(0, 1)] float isOnBeatTolerance = 0;
    [Range(1, 10)] public int beatsProStep = 2;
    int nextBeatWithStep = 1;
    [HideInInspector] public int beats;
    [Header("Sound")]
    [SerializeField] int[] soundLayerSteps = new int[7];
    [SerializeField] int minBeatBetweenVoiceLine;
    [SerializeField] int maxBeatBetweenVoiceLine;
    [SerializeField] int beatOfnextVoiceLine;



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
    }

    // Update is called once per frame
    void Update()
    {
        if (startingTime != 0)
        {
            CheckForBeat();
        }
    }


    public void Gamestart()
    {
        startingTime = Time.time;
        SoundManager.soundManagerInstance.ResetMusicLayer();
    }
    public void CheckForBeat()
    {
        float currentTime = Time.time - startingTime;
        float pastTimeSinceLastBeat = currentTime - lastBeatTime;
        int beats = Mathf.FloorToInt(pastTimeSinceLastBeat / beatLength);


        for (int i = 0; i < beats; i++)
        {
            OnBeat();
        }
    }
    void OnBeat()
    {
        Debug.Log("uz");
        beats += 1;
        lastBeatTime += beatLength;
        CheckForSoundlayer();
       // CheckForVoiceLine();
        if (beats == nextBeatWithStep)
        {

            nextBeatWithStep += beatsProStep;
            float timeSinceLastStep = Time.time - lastBeatTime;
            float timeUntilNextStep = (beatLength * beatsProStep) - timeSinceLastStep;
            //Debug.Log(timeUntilNextStep);
            //Debug.Log(InputManager.instance.name);
            //InputManager.instance.SignalNextBeat(Stepmanager.Instance.GetnextInput(), timeUntilNextStep);

        }
    }
    public bool IsStepOnBeat(float time)
    {
        float targetBeatTime = startingTime + (nextBeatWithStep * beatLength);
        return IsOnBeat(targetBeatTime, time);
    }

    public bool IsOnBeat(float targetBeatTime, float time)
    {
        float currentTime = time - startingTime;
        if (currentTime >= targetBeatTime - isOnBeatTolerance || currentTime <= targetBeatTime - beatLength * beatsProStep + isOnBeatTolerance)
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

    void CheckForSoundlayer()
    {
        if (SoundManager.soundManagerInstance.layerState < 6 && beats >= soundLayerSteps[SoundManager.soundManagerInstance.layerState])
        {
            SoundManager.soundManagerInstance.PlayVoiceLine();
            SoundManager.soundManagerInstance.AddMusicLayer();
        }
    }

    void CheckForVoiceLine()
    {
        if (beatOfnextVoiceLine == 0)
        {
            beatOfnextVoiceLine = Random.Range(minBeatBetweenVoiceLine, maxBeatBetweenVoiceLine);
        }
        else if (beats >= beatOfnextVoiceLine)
        {
            SoundManager.soundManagerInstance.PlayVoiceLine();
            beatOfnextVoiceLine += Random.Range(minBeatBetweenVoiceLine, maxBeatBetweenVoiceLine);
            Debug.Log("voiceline");
        }

    }

}
