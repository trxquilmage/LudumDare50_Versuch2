using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] FeedbackImage currentFeedbackImage;
    [SerializeField] Animator anim;

    public enum Inputs
    {
        Left, Right, Jump, Duck
    }

    Controls controls;

    void Awake()
    {
        AssignSingleton();
    }
    void Start()
    {
        AssignInputTriggers();
    }
    void AssignSingleton()
    {
#if UNITY_EDITOR
        if (instance != null)
        {
            Debug.LogWarning("You have more than one InputManager in scene");
        }
#endif
        instance = this;
    }
    void AssignInputTriggers()
    {
        controls = new Controls();
        controls.Enable();
        controls.MovementPrompts.Left.performed += context => DoAction(Inputs.Left, context.time);
        controls.MovementPrompts.Right.performed += context => DoAction(Inputs.Right, context.time);
        controls.MovementPrompts.Jump.performed += context => DoAction(Inputs.Jump, context.time);
        controls.MovementPrompts.Duck.performed += context => DoAction(Inputs.Duck, context.time);
    }
    void DoAction(Inputs inputs, double time)
    {
        if (FeedbackManager.instance.CheckIfInputWasCorrect(inputs))
        {
            FeedbackManager.instance.DealWithFeedback(inputs);
            TriggerAnimation(inputs);
            CompareToBeatTime(inputs, (float)time);
        }
    }
    void CompareToBeatTime(Inputs inputs, float time)
    {
        if (BeatManager.instance.IsStepOnBeat(time))
        {
            SoundManager.soundManagerInstance.PlayFootstep();
            //Player.ContinueWalking();
        }
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    void TriggerAnimation(Inputs input) 
    {
        if (input == Inputs.Jump) 
        {
            anim.SetTrigger("jump");
        }
        else if (input == Inputs.Duck) 
        {
            anim.SetTrigger("duck");
        }


    }
}