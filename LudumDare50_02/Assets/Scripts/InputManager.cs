using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] bool usesLeftAndRight = true;
    [SerializeField] FeedbackImage feedbackImage;
    [SerializeField] CircleImage circleImage;

    public enum Inputs
    {
        Left, Right, Jump, Duck
    }
    float[] lastInputTime = new float[4];
    bool lastStepWasWrong;

    Controls controls;
    Dictionary<Inputs, bool> currentPossibleKeys = new Dictionary<Inputs, bool>();
    Inputs lastPressedKey = Inputs.Jump;

    public void SignalNextBeat(Inputs inputs, float timeTilHit)
    {
        if (usesLeftAndRight)
            ManagePossibleKeyList();
        PortrayFeedback(inputs, timeTilHit);
    }

    void Awake()
    {
        AssignSingleton();
    }
    void Start()
    {
        AssignInputTriggers();
        AssignValues();
        SignalNextBeat(Inputs.Duck, 2f);
    }
    void AssignSingleton()
    {
    #if UNITY_EDITOR
        if (instance != null)
        {
            Debug.LogWarning("You have more than one InputManager in scene");
        }
    #endif
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
    void AssignValues()
    {
        currentPossibleKeys[Inputs.Duck] = true;
        currentPossibleKeys[Inputs.Jump] = true;
    }
    void DoAction(Inputs inputs, double time)
    {
        SetLastPressed(inputs);
        if (PressedCorrectKey(inputs))
        {
            feedbackImage.HighlightIfActiveBeat(inputs);
            CompareToBeatTime(inputs, (float)time);
        }
    }
    void CompareToBeatTime(Inputs inputs, float time)
    {
        if (BeatManager.instance.IsStepOnBeat(time))
        {
            Debug.Log("Correct Key -> Is On Beat!");
            //Player.ContinueWalking();
        }
    }
    bool PressedCorrectKey(Inputs inputs)
    {
        return currentPossibleKeys[inputs];
    }
    void SetLastPressed(Inputs lastInput)
    {
        lastPressedKey = lastInput;
    }
    void ManagePossibleKeyList()
    {
        if ((int)lastPressedKey > 1 || lastStepWasWrong)
        {
            currentPossibleKeys[Inputs.Left] = true;
            currentPossibleKeys[Inputs.Right] = true;
        }
        else
        {
            currentPossibleKeys[Inputs.Left] = lastPressedKey != Inputs.Left;
            currentPossibleKeys[Inputs.Right] = lastPressedKey != Inputs.Right;
        }
    }
    void PortrayFeedback(Inputs inputs, float timeTilHit)
    {
        feedbackImage.SwitchImageAndResetTimer(inputs);
        circleImage.HitOnBeat(timeTilHit);
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}