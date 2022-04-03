using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManagerInstance;

    public int layerState;

    // SOUND LIBRARY
    [SerializeField] AudioClip[] footSteps;
    [SerializeField] AudioSource footStep;

    [SerializeField] AudioClip[] voiceLines;
    [SerializeField] AudioSource voiceLine;

    [SerializeField] AudioSource escalator;

    // VOLUMES
    //[SerializeField] float minVol, BGVol, maxVol;

    // MIXER
    [SerializeField] AudioMixer audioMixer;

    // LAYER
    [SerializeField] AudioMixerSnapshot[] layers;

    [SerializeField] float transitionTime;

    //DEBUG
    float timer;

    private void Awake()
    {
        soundManagerInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetMusicLayer();

        EscalatorSound(true);
    }
    private void Update()
    {
        //DEBUG
        //timer += Time.deltaTime;

        //if(timer > 30)
        //{
        //    AddMusicLayer();

        //    timer = 0;
        //}
        
    }

    public void AddMusicLayer()
    {
        layerState++;

        layers[layerState].TransitionTo(transitionTime);
    }
    public void ResetMusicLayer()
    {
        layers[0].TransitionTo(transitionTime);
    }

    // SOUNDS
    public void PlayFootstep()
    {
        footStep.clip = footSteps[Random.Range(0, footSteps.Length)];
        footStep.Play();
    }

    public void PlayVoiceLine()
    {
        voiceLine.clip = voiceLines[Random.Range(0, voiceLines.Length)];
        voiceLine.Play();
    }

    public void EscalatorSound(bool play)
    {
        if (play)
        {
            escalator.Play();
        }
        else
        {
            escalator.Stop();
        }
    }
}
